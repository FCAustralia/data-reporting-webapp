using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Form.ViewModels;
using Microsoft.AspNetCore.Http;
using App.Data;
using App.Service;
using App.Domain;
using System;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Form.Controllers
{
    public class DossierController : Controller
    {
        private readonly ILogger<DossierController> _logger;
        private readonly IRepository _repo;
        private readonly IMailer _mailer;
        private const string SUBJECT = "CASE STUDY SUBMISSION TO FCA";
        private const string EMAIL_TEXT = "Please see your submission.";
        private const string NOTIFY = "mel.gibson@financialcounsellingaustralia.org.au";
        private const string NOTIFY_TEXT = "Please see NEW submission.";
        private const string EDIT_LINK_TEXT = "A link to edit your submission has been sent to your emailed. To request IT support please send an email to support@fca-help.zendesk.com.";

        public DossierController(ILogger<DossierController> logger, IRepository repository, IMailer mailer)
        {
            _logger = logger;
            _repo = repository;
            _mailer = mailer;
        }
        // GET: /<controller>/
        [HttpGet("index")]
        public IActionResult Index(Guid id)
        {
            
            if (id != Guid.Empty)
            {
                try
                {
                    var found = Mappers.MapFormInputToDossier
                        .DossierToFormInput(_repo.Find(id));
                    return View(found);
                }
                catch (System.Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
                return View();
            }

            ViewBag.Organisations = Mappers.MapFormInputToDossier.BuildSelectList();

            return View();
        }

        [HttpPost("index")]
        public IActionResult Index(IFormCollection search)
        {
            var id = search["Organisation"];
            try
            {
                
                var found = Mappers.MapFormInputToDossier.DossierToFormInput(
                                    _repo.GetDossierByOrg(id));
                return View(found);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return RedirectToAction("Create", "Dossier", new { org = id });
        }

        [HttpGet("editableLink")]
        public IActionResult EditableLink(Guid id)
        {
            try
            {
                var found = _repo.Find(id);
                EmailEditLink(found);
                TempData["EmailLinkSent"] = EDIT_LINK_TEXT;
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return RedirectToAction("Index", "Dossier");
        }

        [HttpGet("edit")]
        public IActionResult Edit(Guid id)
        {
            try
            {
                var found = Mappers.MapFormInputToDossier
                    .DossierToFormInput(_repo.Find(id));
                return View(found);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return View("Index");
        }

        [HttpPost("edit")]
        public IActionResult Edit(FormInput model)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var dossierUpdate = _repo.Find(model.Id);
                    Mappers.MapFormInputToDossier.UpdateDossierFromFormInput(ref dossierUpdate, ref model);
                    _repo.SaveAll();
                    EmailReceipt(dossierUpdate);
                    NotifyNewCaseStudy(dossierUpdate);
                    return RedirectToAction("Index", "Dossier", new { id = model.Id });
                }
                catch (System.Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
                
            }
            
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create(string org)
        {
            var model = new FormInput() { SelectedOrganisation = org };
            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormInput model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dossier = Mappers.MapFormInputToDossier.NewFormInputToDossier(model);
                    _repo.AddDossier(dossier);
                    _repo.SaveAll();
                    EmailReceipt(dossier);
                    NotifyNewCaseStudy(dossier);
                    return RedirectToAction("Index", "Dossier", new { id = dossier.Id });
                }
                catch (System.Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
                
            }
            
            return View(model);
        }


        public IActionResult List()
        {
            var model = new List<LinkToSubmission>();
            var list = _repo.AllSubmissions();

            foreach(var dossier in list)
            {
                model.Add(Mappers.MapFormInputToDossier.DossierToLinkToSubmission(dossier));
            }

            return View(model);
        }    

        private bool EmailEditLink(Dossier model)
        {
            var response = _mailer.Send(model.Email, model.Reporter,
                            model.Organisation + " " + SUBJECT + " " + System.DateTime.Now.ToShortDateString(),
                            EMAIL_TEXT + " " + Url.ActionLink("Edit", "Dossier", new { id = model.Id }));
            response.Wait();
            _logger.LogInformation(response.IsCompletedSuccessfully.ToString());
            return response.IsCompletedSuccessfully;
        }
        private bool EmailReceipt(Dossier model)
        {
            var response = _mailer.Send(model.Email, model.Reporter,
                            model.Organisation + " " + SUBJECT + " " + System.DateTime.Now.ToShortDateString(),
                            EMAIL_TEXT + " " + Url.ActionLink("Index", "Dossier", new { id = model.Id }));
            response.Wait();
            _logger.LogInformation(response.IsCompletedSuccessfully.ToString());
            return response.IsCompletedSuccessfully;
        }
        private bool NotifyNewCaseStudy(Dossier model)
        {
            var response = _mailer.Send(NOTIFY, null,
                            model.Organisation + " " + SUBJECT + " " + System.DateTime.Now.ToShortDateString(),
                            NOTIFY_TEXT + " " + Url.ActionLink("Index", "Dossier", new { id = model.Id }));
            response.Wait();
            _logger.LogInformation(response.IsCompletedSuccessfully.ToString());
            return response.IsCompletedSuccessfully;
        }

    }
}

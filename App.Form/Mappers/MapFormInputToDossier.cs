using System.Collections.Generic;
using App.Domain;
using App.Form.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Form.Mappers
{
    public static class MapFormInputToDossier
    {
        public static Dossier NewFormInputToDossier(FormInput model)
        {
            return new Dossier
            {
                Organisation = model.SelectedOrganisation,
                Reporter = model.Reporter,
                Email = model.Email,
                ConsentOne = model.ConsentOne,
                CsOneQuestionOne = model.CsOneQuestionOne,
                CsOneQuestionTwo = model.CsOneQuestionTwo,
                CsOneQuestionThree = model.CsOneQuestionThree,
                CsOneQuestionFour = model.CsOneQuestionFour,
                CsOneQuestionFive = model.CsOneQuestionFive,
                CsOneQuestionSix = model.CsOneQuestionSix,
                ConsentTwo = model.ConsentTwo,
                CsTwoQuestionOne = model.CsTwoQuestionOne,
                CsTwoQuestionTwo = model.CsTwoQuestionTwo,
                CsTwoQuestionThree = model.CsTwoQuestionThree,
                CsTwoQuestionFour = model.CsTwoQuestionFour,
                CsTwoQuestionFive = model.CsTwoQuestionFive,
                CsTwoQuestionSix = model.CsTwoQuestionSix
            };
        
        }

        

        public static FormInput DossierToFormInput(Dossier model)
        {
            return new FormInput
            {
                Id = model.Id,
                SelectedOrganisation = model.Organisation,
                Reporter = model.Reporter,
                Email = model.Email,
                ConsentOne = model.ConsentOne,
                CsOneQuestionOne = model.CsOneQuestionOne,
                CsOneQuestionTwo = model.CsOneQuestionTwo,
                CsOneQuestionThree = model.CsOneQuestionThree,
                CsOneQuestionFour = model.CsOneQuestionFour,
                CsOneQuestionFive = model.CsOneQuestionFive,
                CsOneQuestionSix = model.CsOneQuestionSix,
                ConsentTwo = model.ConsentTwo,
                CsTwoQuestionOne = model.CsTwoQuestionOne,
                CsTwoQuestionTwo = model.CsTwoQuestionTwo,
                CsTwoQuestionThree = model.CsTwoQuestionThree,
                CsTwoQuestionFour = model.CsTwoQuestionFour,
                CsTwoQuestionFive = model.CsTwoQuestionFive,
                CsTwoQuestionSix = model.CsTwoQuestionSix
            };

        }

        public static void UpdateDossierFromFormInput(ref Dossier dossierUpdate, ref FormInput model)
        {
            dossierUpdate.Organisation = model.SelectedOrganisation;
            dossierUpdate.Reporter = model.Reporter;
            dossierUpdate.Email = model.Email;
            dossierUpdate.ConsentOne = model.ConsentOne;
            dossierUpdate.CsOneQuestionOne = model.CsOneQuestionOne;
            dossierUpdate.CsOneQuestionTwo = model.CsOneQuestionTwo;
            dossierUpdate.CsOneQuestionThree = model.CsOneQuestionThree;
            dossierUpdate.CsOneQuestionFour = model.CsOneQuestionFour;
            dossierUpdate.CsOneQuestionFive = model.CsOneQuestionFive;
            dossierUpdate.CsOneQuestionSix = model.CsOneQuestionSix;

            dossierUpdate.ConsentTwo = model.ConsentTwo;
            dossierUpdate.CsTwoQuestionOne = model.CsTwoQuestionOne;
            dossierUpdate.CsTwoQuestionTwo = model.CsTwoQuestionTwo;
            dossierUpdate.CsTwoQuestionThree = model.CsTwoQuestionThree;
            dossierUpdate.CsTwoQuestionFour = model.CsTwoQuestionFour;
            dossierUpdate.CsTwoQuestionFive = model.CsTwoQuestionFive;
            dossierUpdate.CsTwoQuestionSix = model.CsTwoQuestionSix;
        }

        public static LinkToSubmission DossierToLinkToSubmission(Dossier model)
        {
            return new LinkToSubmission
            {
                Id = model.Id,
                Organisation = model.Organisation
            };

        }


        public static IEnumerable<SelectListItem> BuildSelectList()
        {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "Select your organisation...", Value = "", Disabled = true, Selected = true});
            var items = new List<string>
            {
                "Anglican Community Services","Anglicare North Coast","Anglicare NSW South","Anglicare Tasmania Inc.","Anglicare Victoria","C.A.R.E.","Financial Counselling Australia","Gosford City Community & Information Service Ltd","Kempsey Neighbourhood Centre Incorporated","Latrobe Community Health Service Limited","Lifeline Central West Incorporated","Lifeline Harbour to Hawkesbury Incorporated","Lismore and District Financial Counselling Service","Mission Australia","Samaritans Foundation-Diocese of Newcastle","Shoalhaven Women's Health Centre Inc","The Family Place","The Salvation Army (NSW)","The Salvation Army (SA)","The Salvation Army (QLD)","Uniting (NSW.ACT)","Uniting (Qld)","Uniting Country SA Ltd","Upper Murray Family Care Inc.","Wagga Wagga Family Support Service Inc","Wesley Community Services Limited","Wyong Neighbourhood Centre Inc"
            };
            items.Sort();
            foreach(string item in items)
            {
                listItems.Add(new SelectListItem { Text = item, Value = item });
            }
            return listItems;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Form.ViewModels
{
    public class FormInput
    {
        [ValidateNever]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please select your organisation.")]
        [Display(Name = "Select your organisation: ")]
        public string SelectedOrganisation { get; set; }
        public IEnumerable<SelectListItem> Organisations { get; set; } = Mappers.MapFormInputToDossier.BuildSelectList();
        [Required(ErrorMessage = "Please add your name.")]
        [StringLength(70)]
        [Display(Name ="Reporter Name")]
        public string Reporter { get; set; }
        [Required(ErrorMessage ="Please add a valid email address.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Case Study One, consent is required.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Case Study One, consent is required.")]
        [DisplayName("I have permission from the client to share this story which has been de-identified")]
        public bool ConsentOne { get; set; }
        [Required(ErrorMessage = "Case Study One, question one answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("1. Background (brief explanation of client’s situation including vulnerabilities) ")]
        public string CsOneQuestionOne { get; set; }
        [Required(ErrorMessage = "Case Study One, question two answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("2. What work did the financial counsellor do?")]
        public string CsOneQuestionTwo { get; set; }
        [Required(ErrorMessage = "Case Study One, question three answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("3. What was the outcome for the client?")]
        public string CsOneQuestionThree { get; set; }
        [Required(ErrorMessage = "Case Study One, question four answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("4. Did you receive any feedback from the client?  If so, can you please share it with us.")]
        public string CsOneQuestionFour { get; set; }
        [Required(ErrorMessage = "Case Study One, question five answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("5. Were there any broader effects in the community as a result of your work with this client?")]
        public string CsOneQuestionFive { get; set; }
        [Required(ErrorMessage = "Case Study One, question six answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("6. What reflections would you like to share about this case?")]
        public string CsOneQuestionSix { get; set; }
        [Required(ErrorMessage = "Case Study Two, consent is required for.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Case Study Two, consent is required.")]
        [DisplayName("I have permission from the client to share this story which has been de-identified")]
        public bool ConsentTwo { get; set; }
        [Required(ErrorMessage = "Case Study Two, question one answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("1. Background (brief explanation of client’s situation including vulnerabilities) ")]
        public string CsTwoQuestionOne { get; set; }
        [Required(ErrorMessage = "Case Study Two, question two answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("2. What work did the financial counsellor do?")]
        public string CsTwoQuestionTwo { get; set; }
        [Required(ErrorMessage = "Case Study Two, question three answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("3. What was the outcome for the client?")]
        public string CsTwoQuestionThree { get; set; }
        [Required(ErrorMessage = "Case Study Two, question four answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("4. Did you receive any feedback from the client?  If so, can you please share it with us.")]
        public string CsTwoQuestionFour { get; set; }
        [Required(ErrorMessage = "Case Study Two, question five answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("5. Were there any broader effects in the community as a result of your work with this client?")]
        public string CsTwoQuestionFive { get; set; }
        [Required(ErrorMessage = "Case Study Two, question six answer is required.")]
        [DataType(DataType.MultilineText)]
        [DisplayName("6. What reflections would you like to share about this case?")]
        public string CsTwoQuestionSix { get; set; }
    }
}

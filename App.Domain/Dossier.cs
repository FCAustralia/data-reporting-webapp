using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
    public class Dossier
    {
        [Key]
        public Guid Id { get; set; }
        public string Organisation { get; set; }
        public string Email { get; set; }
        public string Reporter { get; set; }
        public bool ConsentOne { get; set; }
        public string CsOneQuestionOne { get; set; }
        public string CsOneQuestionTwo { get; set; }
        public string CsOneQuestionThree { get; set; }
        public string CsOneQuestionFour { get; set; }
        public string CsOneQuestionFive { get; set; }
        public string CsOneQuestionSix { get; set; }
        public bool ConsentTwo { get; set; }
        public string CsTwoQuestionOne { get; set; }
        public string CsTwoQuestionTwo { get; set; }
        public string CsTwoQuestionThree { get; set; }
        public string CsTwoQuestionFour { get; set; }
        public string CsTwoQuestionFive { get; set; }
        public string CsTwoQuestionSix { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int cId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        [Display(Name = "Antal rätta svar")]
        public int CorrAnswers { get; set; }
    }
}
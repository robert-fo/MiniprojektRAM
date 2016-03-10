using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int cId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [ForeignKey("cId")]
        public virtual QuestionCategory questionCategory { get; set; }

    }
}
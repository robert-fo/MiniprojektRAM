using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.Models
{
    public class QuestionCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Frågekategori")]
        public int CatName { get; set; }
    }
}
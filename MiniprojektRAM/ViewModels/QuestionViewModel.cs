using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.ViewModels
{
    //När man genererar en edit view med denna som modell så vill Vs lägga till det i databasen,
    //så ta bort raden för denna klass i DataAccessLayer/ItemContext.cs filen efter att ni genererat
    //en vy med denna klass som modellklass eftersom denna ska vara helt frikopplad från databasen.
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int cId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int CorrAnswers { get; set; }
    }
}
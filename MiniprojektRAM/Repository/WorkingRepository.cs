using MiniprojektRAM.DataAccessLayer;
using MiniprojektRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.Repository
{
    public class WorkingRepository
    {
        private ItemContext db;

        public WorkingRepository()
        {
            db = new ItemContext();
        }

        public List<Question> GetAllCategorieQuestions(int id)
        {
            var questions =  db.Question.ToList();
            var queryQuestions = from question in questions
                            where question.cId == id
                            select question;

            var result = queryQuestions.ToList();

            return result;
        }

        public List<QuestionCategory> GetAllCategories()
        {
            var questionCats = db.QuestionCategory.ToList();

            return questionCats;
        }

    }
}
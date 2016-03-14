using MiniprojektRAM.DataAccessLayer;
using MiniprojektRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniprojektRAM.Repository
{
    public class WorkingRepositoryV2 : IRepository
    {
        private ItemContext db;

        public WorkingRepositoryV2()
        {
            db = new ItemContext();
        }

        public List<Question> GetAllCategorieQuestions()
        {
            var questions = db.Question.ToList();

            return questions;
        }

        public List<QuestionCategory> GetAllCategories()
        {
            var questionCats = db.QuestionCategory.ToList();

            return questionCats;
        }

    }
}
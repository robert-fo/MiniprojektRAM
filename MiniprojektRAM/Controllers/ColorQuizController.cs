using MiniprojektRAM.Models;
using MiniprojektRAM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniprojektRAM.Controllers
{
      
    
    public class ColorQuizController : Controller
    {

        private WorkingRepository repository;

        public ColorQuizController()
        {
            this.repository = new WorkingRepository();
        }
        
        // GET: ColorQuiz
        public ActionResult Index()
        {
            return View();
        }

        // GET: ColorQuiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColorQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorQuiz/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorQuiz/Edit/5
        public ActionResult Edit()
        {
            var questions = repository.GetAllCategorieQuestions(1);

            ViewBag.QuestionId = 0; 
            int i = 0;

            foreach (var item in questions) 
            {
                if (i == ViewBag.QuestionId)
                {
                    return View(item);
                }
                i++;
            }
            return RedirectToAction("Index");
            
        }

        // POST: ColorQuiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Question question)
        {
            try
            {
                // TODO: Add update logic here
               var questions = repository.GetAllCategorieQuestions(1);

                foreach (var item in questions)
                {
                    if (item.Id == question.Id)
                    {
                        if (item.AnswerText.ToLower() == question.AnswerText.ToLower())
                        {

                            ViewBag.CorrectAnswers++;
                            ViewBag.FeedBack = "You answered correctly";
                        }
                        else
                        {
                            ViewBag.FeedBack = "Your answer was wrong, the correct answer is" + item.AnswerText;
                        }
                        return View(item);
                    }
                    i++;
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColorQuiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

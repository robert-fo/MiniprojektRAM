using MiniprojektRAM.Models;
using MiniprojektRAM.Repository;
using MiniprojektRAM.ViewModels;
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
            ViewBag.FeedBack = "Ny fråga.";
            ViewBag.QuestionId = 0; 

            int i = 0;

            foreach (var item in questions) 
            {
                if (i == ViewBag.QuestionId)
                {
                    QuestionViewModel Vquestion = new QuestionViewModel();
                    Vquestion.Id = item.Id;
                    Vquestion.cId = item.cId;
                    Vquestion.QuestionText = item.QuestionText;
                    Vquestion.AnswerText = item.AnswerText;
                    Vquestion.CorrAnswers = 0;
                    return View(Vquestion);
                }
                i++;
            }
            return RedirectToAction("Index");
            
        }

        // POST: ColorQuiz/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestionViewModel question)
        {
            try
            {
                // TODO: Add update logic here
                var questions = repository.GetAllCategorieQuestions(1);
                //string ScorrAnswer = ViewBag.corrAnswer as string;
                int corrAnswer = question.CorrAnswers; //Convert.ToInt32(ScorrAnswer);

                foreach (var item in questions)
                {
                    if (item.Id == question.Id)
                    {
                        if (item.AnswerText.ToLower() == question.AnswerText.ToLower())
                        {

                            corrAnswer++;
                            ViewBag.FeedBack = "Du svarade rätt.";
                        }
                        else
                        {
                            ViewBag.FeedBack = "Du svarade fel, rätt svar är: " + item.AnswerText;
                        }
                        ViewBag.corrAnswer = corrAnswer;
                        QuestionViewModel Vquestion = new QuestionViewModel();
                        Vquestion.Id = item.Id;
                        Vquestion.cId = item.cId;
                        Vquestion.QuestionText = item.QuestionText;
                        Vquestion.AnswerText = item.AnswerText;
                        Vquestion.CorrAnswers = corrAnswer;
                        return View(Vquestion);
                    }
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

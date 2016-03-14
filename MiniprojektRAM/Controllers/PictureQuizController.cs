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
      
    
    public class PictureQuizController : Controller
    {

        private WorkingRepository repository;

        public PictureQuizController()
        {
            this.repository = new WorkingRepository();
        }
        
        // GET: PictureQuiz
        public ActionResult Index()
        {
            //ViewBag.CorrectAnswers = TempData["corrAnswer"];
            //return View();

            if (TempData["corrAnswer"] != null)
            {
                ViewBag.CorrectAnswers = TempData["corrAnswer"];
                ViewBag.FeedBack = TempData["FeedBack"];
                // Nollställ så man kan köra en ny Quiz
                TempData["corrAnswer"] = null;
                TempData["QuestionId"] = null;
                TempData["FeedBack"] = null;
            }

            return View();
        }

        // GET: PictureQuiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PictureQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PictureQuiz/Create
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

        // GET: PictureQuiz/Edit/5
        public ActionResult Edit()
        {
            var questions = repository.GetAllCategorieQuestions(1);
            int i = 1;

            if (TempData["corrAnswer"] == null)
            {
                TempData["corrAnswer"] = 0;
            }

            if (TempData["QuestionId"] == null)
            {
                TempData["QuestionId"] = 1;
            }

            if (TempData["FeedBack"] == null)
            {
                ViewBag.FeedBack = "Ny fråga.";
            }
            else
            {
                ViewBag.FeedBack = TempData["FeedBack"];
                TempData.Keep("FeedBack");
            }

            int corrAnswer = Convert.ToInt32(TempData["corrAnswer"]);

            foreach (var item in questions)
            {
                if (i == Convert.ToInt32(TempData["QuestionId"]))
                {
                    QuestionViewModel Vquestion = new QuestionViewModel();
                    Vquestion.Id = item.Id;
                    Vquestion.cId = item.cId;
                    Vquestion.QuestionText = item.QuestionText;
                    Vquestion.AnswerText = item.AnswerText; 
                    Vquestion.CorrAnswers = corrAnswer;
                    return View(Vquestion);
                }
                i++;
            }
            return RedirectToAction("Index");
            
            //var questions = repository.GetAllCategorieQuestions(1);
            //ViewBag.FeedBack = "Ny fråga.";

            //ViewBag.QuestionId = 0; 

            //int i = 1;

            //if (TempData["corrAnswer"] == null)
            //{
            //    TempData["corrAnswer"] = 0;
            //}

            //if (TempData["QuestionId"] == null)
            //{
            //    TempData["QuestionId"] = 1;
            //}

            //int corrAnswer = Convert.ToInt32(TempData["corrAnswer"]);

            //foreach (var item in questions) 
            //{
            //    if (i == Convert.ToInt32(TempData["QuestionId"]))
            //    {
            //        QuestionViewModel Vquestion = new QuestionViewModel();
            //        Vquestion.Id = item.Id;
            //        Vquestion.cId = item.cId;
            //        Vquestion.QuestionText = item.QuestionText;
            //        Vquestion.AnswerText = item.AnswerText;
            //        Vquestion.CorrAnswers = corrAnswer;
            //        return View(Vquestion);
            //    }
            //    i++;
            //}
            //return RedirectToAction("Index");
            
        }

        // POST: PictureQuiz/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestionViewModel question)
        {
            try
            {
                // TODO: Add update logic here
                var questions = repository.GetAllCategorieQuestions(1);
                int corrAnswer = question.CorrAnswers;
                int i = 1;

                foreach (var item in questions)
                {
                    if (item.Id == question.Id)
                    {
                        if (item.AnswerText.ToLower() == question.AnswerText.ToLower())
                        {

                            corrAnswer++;
                            TempData["FeedBack"] = "Du svarade rätt.";
                        }
                        else
                        {
                            TempData["FeedBack"] = "Du svarade fel, rätt svar är: " + item.AnswerText;
                        }
                        //TempData används för att skicka data mellan olika actionanro i samma controller,
                        // fungerar bara med Redirect. I detta fal för att antal rätta svar ska sparas mellan
                        // svaren.
                        TempData["corrAnswer"] = corrAnswer;
                        //Så att nästa fråga i listan med frågor i kategorin väljs i Get actionen
                        TempData["QuestionId"] = i + 1;
                        // Man måste redirecta till Get acionen för att vyn ska ta med allt data från modellen
                        // Man kan alltså inte returnera vyn med objektet direkt i en post action
                        return RedirectToAction("Edit");
                    }
                    i++;
                }

                return View();
            }
            catch
            {
                return View();
            }

            //try
            //{
            //    // TODO: Add update logic here
            //    var questions = repository.GetAllCategorieQuestions(1);
            //    int corrAnswer = question.CorrAnswers; //Convert.ToInt32(ScorrAnswer);
            //    int i = 1;

            //    foreach (var item in questions)
            //    {
            //        if (item.Id == question.Id)
            //        {
            //            if (item.AnswerText.ToLower() == question.AnswerText.ToLower())
            //            {

            //                corrAnswer++;
            //                ViewBag.FeedBack = "Du svarade rätt.";
            //            }
            //            else
            //            {
            //                ViewBag.FeedBack = "Du svarade fel, rätt svar är: " + item.AnswerText;
            //            }
            //            TempData["corrAnswer"] = corrAnswer;
            //            TempData["QuestionId"] = i+1;

            //            return RedirectToAction("Edit");
            //        }
            //        i++;
            //    }

            //    return View();
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: PictureQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PictureQuiz/Delete/5
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

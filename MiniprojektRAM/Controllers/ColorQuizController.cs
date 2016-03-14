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

        private IRepository repository;

        public ColorQuizController()
        {
            this.repository = new WorkingRepositoryV2();
        }

        public ColorQuizController(IRepository questionRepository)
        {
            // TODO: Complete member initialization
            this.repository = questionRepository;
        }
        
        // GET: ColorQuiz
        public ActionResult Index()
        {
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
        public ActionResult TakeQuiz()
        {
            var questions = repository.GetAllCategorieQuestions();

            var queryQuestions = from question in questions
                                 where question.cId == 3
                                 orderby question.Id
                                 select question;

            var catquestions = queryQuestions.ToList();

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

            foreach (var item in catquestions) 
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
            
        }

        // POST: ColorQuiz/Edit/5
        [HttpPost]
        [ActionName("TakeQuiz")]
        public ActionResult TakeQuizPost(QuestionViewModel question)
        {
            try
            {
                // TODO: Add update logic here
                var questions = repository.GetAllCategorieQuestions();

                var queryQuestions = from q in questions
                                     where q.cId == 3
                                     orderby question.Id
                                     select q;

                var catquestions = queryQuestions.ToList();

                int corrAnswer = question.CorrAnswers;
                int i = 1;

                foreach (var item in catquestions)
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
                        TempData["QuestionId"] = i+1;
                        // Man måste redirecta till Get acionen för att vyn ska ta med allt data från modellen
                        // Man kan alltså inte returnera vyn med objektet direkt i en post action
                        return RedirectToAction("TakeQuiz", new { id = 0 });
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

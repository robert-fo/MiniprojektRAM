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


    public class SeparatorQuizController : Controller
    {

        private WorkingRepository repository;

        public SeparatorQuizController()
        {
            this.repository = new WorkingRepository();
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

        // GET: SeparateQuiz/Edit/5
        public ActionResult Edit()
        {
            var questions = repository.GetAllCategorieQuestions(2);
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
        }

        // POST: SeparateQuiz/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestionViewModel question)
        {
            try
            {
                // TODO: Add update logic here
                var questions = repository.GetAllCategorieQuestions(2);
                int corrAnswer = question.CorrAnswers;
                int right = 0;
                int wrong = 0;
                int i = 1;
                String s = "";
                foreach (var item in questions)
                {
                    s = item.QuestionText;
                    char c = ' ';
                    if (item.Id == question.Id)
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            c = s[j];
                            if (c == '*')
                            {
                                if ((question.AnswerText.Length > j) && (item.AnswerText[j] == question.AnswerText[j]))
                                {
                                    corrAnswer++;
                                    right++;
                                    TempData["FeedBack"] = "Du svarade rätt.";
                                }
                                else
                                {
                                    wrong++;
                                    TempData["FeedBack"] = "Du svarade fel, rätt svar är: " + item.AnswerText;
                                }
                                //TempData["FeedBack"] = "* at: " + j;
                            }

                        }


                        if (wrong == 0)
                            TempData["FeedBack"] = "Du hade " + right + " rätt";
                        else
                            TempData["FeedBack"] = "Du hade " + right + " rätt och " + wrong + " fel, rätt svar är: " + item.AnswerText;

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

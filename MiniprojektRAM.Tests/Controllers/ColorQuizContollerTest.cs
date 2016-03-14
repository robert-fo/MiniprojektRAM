using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniprojektRAM.Controllers;
using System.Web.Mvc;
using MiniprojektRAM.Models;
using MiniprojektRAM.Repository;
using Telerik.JustMock;
using System.Collections.Generic;
using MiniprojektRAM.ViewModels;

namespace MiniprojektRAM.Tests.Controllers
{
    [TestClass]
    public class ColorQuizContollerTest
    {
        [TestMethod]
        public void Index_Show_ColorQuiz()
        {
            // Arrange
            ColorQuizController controller = new ColorQuizController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TakeQuiz_Get_ColorQuiz()
        {
            //Arrange
            var questionRepository = Mock.Create<IRepository>();
            Mock.Arrange(() => questionRepository.GetAllCategorieQuestions()).
                Returns(new List<Question>()
                {
                    new Question { Id = 1, cId = 1, QuestionText = "Documentation/MiniprojektRAM.png", AnswerText="Klassdiagram" },
                    new Question { Id = 2, cId = 2, QuestionText = "skilje*tecken", AnswerText = "skilje-tecken" },
                    new Question { Id = 3, cId = 3, QuestionText = "Blå", AnswerText = "Blå" },
                    new Question { Id = 4, cId = 4, QuestionText = "hej, svejs, i, lingon, skogen", AnswerText = "hej svejs i lingonskogen" },
                }).MustBeCalled();

            //Act
            ColorQuizController controller = new ColorQuizController(questionRepository);
            ViewResult viewResult = controller.TakeQuiz() as ViewResult;
            var model = viewResult.Model as QuestionViewModel;

            //Assert
            Assert.AreEqual(3, model.Id);
            Assert.AreEqual(3, model.cId);
        }

        [TestMethod]
        public void TakeQuiz_Post_ColorQuiz()
        {
            //Arrange
            var questionRepository = Mock.Create<IRepository>();
            Mock.Arrange(() => questionRepository.GetAllCategorieQuestions()).
                Returns(new List<Question>()
                {
                    new Question { Id = 1, cId = 1, QuestionText = "Documentation/MiniprojektRAM.png", AnswerText="Klassdiagram" },
                    new Question { Id = 2, cId = 2, QuestionText = "skilje*tecken", AnswerText = "skilje-tecken" },
                    new Question { Id = 3, cId = 3, QuestionText = "Blå", AnswerText = "Blå" },
                    new Question { Id = 4, cId = 4, QuestionText = "hej, svejs, i, lingon, skogen", AnswerText = "hej svejs i lingonskogen" },
                }).MustBeCalled();

            //Act
            ColorQuizController controller = new ColorQuizController(questionRepository);
            QuestionViewModel answer = new QuestionViewModel(3, 3, "Blå", "Blå", 0);
            RedirectToRouteResult redirectResult = controller.TakeQuizPost(answer) as RedirectToRouteResult;
            //var corrAnsw = TempData["corrAnswer"];

            //Assert
            //Assert.AreEqual(3, model.Id);
            //Assert.AreEqual(3, model.cId);
            //Assert.AreEqual(1, model.CorrAnswers);

            Assert.AreEqual("TakeQuiz", redirectResult.RouteValues["Action"]);
        }

    }
}

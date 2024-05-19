using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.WebUI.Models;

namespace QuizApp.WebUI.Controllers
{
    public class QuestionController : Controller
    {

        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;

        public QuestionController(IQuizService quizService, IQuestionService questionService)
        {
            _quizService = quizService;
            _questionService = questionService;
        }

        public IActionResult List(int? quizId = null)
        {
            var questionDtos = _questionService.GetQuestionsByQuizId(quizId);

            var viewModel = questionDtos.Select(x => new QuestionListViewModel
            {
                Id = x.Id,
                QuestionText = x.QuestionText,
                Option1Text = x.Option1Text,
                Option2Text = x.Option2Text,
                Option3Text = x.Option3Text,
                Option4Text = x.Option4Text,
                CorrectAnswer = x.CorrectAnswer,
                QuizId = x.QuizId,
                QuizText = x.QuizText

            }).ToList();


            return View(viewModel);


        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

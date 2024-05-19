using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.WebUI.Models;

namespace QuizApp.WebUI.ViewComponents
{
    public class QuizesViewComponent : ViewComponent
    {

        private readonly IQuizService _quizService;

        public QuizesViewComponent(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public IViewComponentResult Invoke()
        {
            var quizDtos = _quizService.GetAllQuiz();

            var viewModel = quizDtos.Select(x => new QuizViewModel
            {
                Id = x.Id,
                Name=x.QuizText


            }).ToList();

            return View(viewModel);

        }




    }
}

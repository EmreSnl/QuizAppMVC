using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.WebUI.Models;

namespace QuizApp.WebUI.ViewComponents
{
    public class QuestionsViewComponent:ViewComponent
    {
        private readonly IQuestionService _questionService;

        public QuestionsViewComponent(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IViewComponentResult Invoke(int? quizId = null)
        {
            var questionDtos = _questionService.GetQuestionsByQuizId(quizId);

            var viewModel = questionDtos.Select(x => new QuestionViewModel
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
    }
}

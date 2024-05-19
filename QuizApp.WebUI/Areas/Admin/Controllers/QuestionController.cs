using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.WebUI.Areas.Admin.Models;

namespace QuizApp.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {


        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;

        public QuestionController(IQuizService quizService, IQuestionService questionService)
        {
            _quizService = quizService;
            _questionService = questionService;  
        }

        public IActionResult List()
        {
            var questionDtoList = _questionService.GetAllQuestion();


            var viewModel = questionDtoList.Select(x => new QuestionListViewModel
            {
                Id = x.Id,
                QuestionText = x.QuestionText,
                Option1Text = x.Option1Text,
                Option2Text = x.Option2Text,
                Option3Text = x.Option3Text,
                Option4Text = x.Option4Text,
                QuizId = x.QuizId,
                CorrectAnswer=x.CorrectAnswer
            }).ToList();

            return View(viewModel);
        }
        public IActionResult New()
        {


            ViewBag.Quizes = _quizService.GetAllQuiz();
            return View("Form", new QuestionFormViewModel());

        }


        public IActionResult Edit(int id)
        {
            var editQuestionDto = _questionService.GetQuestion(id);

            var viewModel = new QuestionFormViewModel()
            {
                Id = editQuestionDto.Id,
                QuestionText = editQuestionDto.QuestionText, 
                Option1Text = editQuestionDto.Option1Text,
                Option2Text = editQuestionDto.Option2Text,
                Option3Text = editQuestionDto.Option3Text,
                Option4Text = editQuestionDto.Option4Text,
                QuizId = editQuestionDto.QuizId,
                CorrectAnswer=editQuestionDto.CorrectAnswer
       
            };


            ViewBag.Quizes = _quizService.GetAllQuiz();
            return View("form", viewModel);

        }


        [HttpPost]
        public IActionResult Save(QuestionFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Quizzes = _quizService.GetAllQuiz();
                return View("Form", formData);
            }

            if (formData.Id == 0) // ekleme
            {
                var addQuestionDto = new AddQuestionDto()
                {
                    QuestionText = formData.QuestionText.Trim(),
                    Option1Text = formData.Option1Text,
                    Option2Text = formData.Option2Text,
                    Option3Text = formData.Option3Text,
                    Option4Text = formData.Option4Text,
                    QuizId = formData.QuizId,
                    CorrectAnswer = formData.CorrectAnswer
                };

                _questionService.AddQuestion(addQuestionDto);
            }
            else
            {
                var updateQuestionDto = new UpdateQuestionDto()
                {
                    QuestionText = formData.QuestionText.Trim(),
                    Option1Text = formData.Option1Text,
                    Option2Text = formData.Option2Text,
                    Option3Text = formData.Option3Text,
                    Option4Text = formData.Option4Text,
                    QuizId = formData.QuizId,
                    CorrectAnswer = formData.CorrectAnswer
                };




                _questionService.UpdateQuestion(updateQuestionDto);

            }
            return RedirectToAction("List");

        }


        public IActionResult Delete(int id)
        {
            _questionService.DeleteQuestion(id);

            return RedirectToAction("List");
        }




    }
}

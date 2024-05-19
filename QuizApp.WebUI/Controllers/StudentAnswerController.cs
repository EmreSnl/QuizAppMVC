using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.WebUI.Extensions;
using QuizApp.WebUI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuizApp.WebUI.Controllers
{
    public class StudentAnswerController : Controller
    {
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IQuestionService _questionService;

        public StudentAnswerController(IStudentAnswerService studentAnswerService, IQuestionService questionService)
        {
            _studentAnswerService = studentAnswerService;
            _questionService = questionService;
        }

        [HttpPost]
        public IActionResult SubmitAnswers(List<int> questionIds, Dictionary<int, string> answers)
        {
            var userId = int.Parse(User.FindFirstValue("id"));


            if (questionIds == null || answers == null)
            {
                return BadRequest("Question IDs or answers are missing.");
            }

            if (questionIds.Count != answers.Count)
            {
                return BadRequest("Question IDs and answers count mismatch.");
            }

            foreach (var questionId in questionIds)
            {
                if (!answers.ContainsKey(questionId))
                {
                    return BadRequest("Answer not found for a question ID.");
                }

                var selectedOption = answers[questionId];
                var question = _questionService.GetQuestion(questionId);

                if (question == null)
                {
                    return NotFound($"Question with ID {questionId} not found.");
                }

                var isCorrect = selectedOption == question.CorrectAnswer;

                var studentAnswer = new AddStudentAnswerDto()
                {
                    StudentId = userId,
                    QuestionId = questionId,
                    Answer = selectedOption,
                    IsCorrect = isCorrect
                };

                _studentAnswerService.AddStudentAnswer(studentAnswer);
            }

            return RedirectToAction("List");
        }

        public IActionResult QuizCompleted()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuizApp.WebUI.Controllers
{
    public class StudentAnswerController : Controller
    {
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IQuestionService _questionService;
        private readonly IStudentResultService _studentResultService;

        public StudentAnswerController(IStudentAnswerService studentAnswerService, IQuestionService questionService, IStudentResultService studentResultService)
        {
            _studentAnswerService = studentAnswerService;
            _questionService = questionService;
            _studentResultService = studentResultService;
        }
        [HttpPost]
        public IActionResult SubmitAnswers(int quizId, List<int> questionIds, Dictionary<int, string> answers)
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

            int correctAnswersCount = 0;
            int totalQuestions = questionIds.Count;

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
                if (isCorrect)
                {
                    correctAnswersCount++;
                }

                var studentAnswer = new AddStudentAnswerDto()
                {
                    StudentId = userId,
                    QuestionId = questionId,
                    Answer = selectedOption,
                    IsCorrect = isCorrect
                };

                _studentAnswerService.AddStudentAnswer(studentAnswer);
            }

            int wrongAnswersCount = totalQuestions - correctAnswersCount;
            int grade = (int)((double)correctAnswersCount / totalQuestions * 100);

            var studentResult = new AddStudentResultDto()
            {
                UserId = userId,
                QuizId = quizId,
                Grade = grade,
                RightAnswers = correctAnswersCount,
                WrongAnswers = wrongAnswersCount
            };

            _studentResultService.AddStudentResult(studentResult);

            return RedirectToAction("QuizCompleted");
        }

        public IActionResult QuizCompleted()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

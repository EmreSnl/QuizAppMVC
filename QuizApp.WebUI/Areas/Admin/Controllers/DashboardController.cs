using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.WebUI.Areas.Admin.Models;

namespace QuizApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IStudentResultService _studentResultService;
        private readonly IUserService _userService;
        private readonly IQuizService _quizService; 

        public DashboardController(IStudentResultService studentResultService, IUserService userService, IQuizService quizService)
        {
            _studentResultService = studentResultService;
            _userService = userService;
            _quizService = quizService; 
        }

        public IActionResult ShowResults()
        {
            var results = _studentResultService.GetAllStudentResult()
                .Select(result => new StudentResultListViewModel
                {
                    UserInfo = _userService.GetUserInfoById(result.UserId),
                    StudentResult = result,
                    QuizName = _quizService.GetQuiz(result.QuizId).QuizText
                })
                .ToList();

            return View(results);
        }
    }
}

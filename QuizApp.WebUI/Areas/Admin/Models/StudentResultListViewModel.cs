using QuizApp.Business.Dtos;

namespace QuizApp.WebUI.Areas.Admin.Models
{
    public class StudentResultListViewModel
    {

        public StudentResultDto StudentResult { get; set; }
        public UserInfoDto UserInfo { get; set; }
        public string QuizName { get; set; }

    }
}

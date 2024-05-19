namespace QuizApp.WebUI.Models
{
    public class StudentAnswerFormViewModel
    {
        public int StudentId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public bool IsCorrect { get; set; }
    }
}

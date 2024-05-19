using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebUI.Areas.Admin.Models
{
    public class QuestionFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "You must fill the question name.")]

        public string QuestionText { get; set; }

        [Display(Name = "Option 1")]
        [Required(ErrorMessage = "You must fill the option 1.")]

        public string Option1Text { get; set; }
        [Display(Name = "Option 2")]
        [Required(ErrorMessage = "You must fill the option 1,2.")]
        public string Option2Text { get; set; }
        [Display(Name = "Option 3")]
        [Required(ErrorMessage = "You must fill the option 3.")]
        public string Option3Text { get; set; }
        [Display(Name = "Option 4")]
        [Required(ErrorMessage = "You must fill the option 1.")]
        public string Option4Text { get; set; }

        [Display(Name = "Quiz")]
        [Required(ErrorMessage = "You must fill the quiz .")]
        public int QuizId { get; set; }

        [Display(Name = "Correct Answer")]
        [Required(ErrorMessage = "You must fill the correct answer")]
        public string CorrectAnswer { get; set; }


    }
}

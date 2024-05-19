using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebUI.Areas.Admin.Models
{
    public class QuizFormViewModel
    {

        public int Id { get; set; } // Bu model ile aynı formdan hem ekleme hem güncelleme yapılacağı için, Id bilgisi de taşınmalı.
        [Display(Name = "Quiz")]
        [Required(ErrorMessage = "You must fill the quiz name.")]
        public string QuizText { get; set; }

        [Display(Name = "Description")]
        [MaxLength(1000)]
        public string? Description { get; set; }
        // ? -> nullable - boş gönderilebilir.
    }
}

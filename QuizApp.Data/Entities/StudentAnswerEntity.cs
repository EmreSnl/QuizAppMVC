using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Entities
{
    public class StudentAnswerEntity : BaseEntity
    {

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

        public QuestionEntity Question { get; set; }  // Navigasyon özelliği


    }
}

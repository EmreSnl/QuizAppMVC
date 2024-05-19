using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Dtos
{
    public class StudentAnswerDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

    }
}

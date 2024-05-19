using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Dtos
{
    public class AddStudentResultDto
    {
        public int UserId { get; set; }

        public int QuizId { get; set; }

        public int Grade { get; set; }

        public int RightAnswers { get; set; }

        public int WrongAnswers { get; set; }

    }
}

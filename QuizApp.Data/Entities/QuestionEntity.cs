﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Entities
{
    public class QuestionEntity : BaseEntity
    {

        public string QuestionText { get; set; }
        public string Option1Text { get; set; }
        public string Option2Text { get; set; }
        public string Option3Text { get; set; }
        public string Option4Text { get; set; }
        public int QuizId { get; set; }
        public string CorrectAnswer { get; set; }

        public QuizEntity Quiz { get; set; }

        public ICollection<StudentAnswerEntity> StudentAnswers { get; set; }  // Navigasyon özelliği






    }
}

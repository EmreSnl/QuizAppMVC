using QuizApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services
{
    public interface IStudentAnswerService
    {
        bool AddStudentAnswer(AddStudentAnswerDto addStudentAnswerDto);

        int UpdateStudentAnswer(UpdateStudentAnswerDto updateStudentAnswerDto);

        StudentAnswerDto GetStudentAnswer(int id);

        int DeleteStudentAnswer(int id);

        List<StudentAnswerDto> GetAllStudentAnswer();
    }
}

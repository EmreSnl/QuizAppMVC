using QuizApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services
{
    public interface IStudentResultService
    {
        bool AddStudentResult(AddStudentResultDto addStudentResultDto);

        int UpdateStudentResult(UpdateStudentResultDto updateStudentResultDto);

        StudentResultDto GetStudentResult(int id);

        int DeleteStudentResult(int id);

        List<StudentResultDto> GetAllStudentResult();
    }
}

using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.Data.Entities;
using QuizApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Managers
{
    public class StudentResultManager : IStudentResultService
    {

        private readonly IGenericRepository<StudentResultEntity> _studentResultRepository;

        public StudentResultManager(IGenericRepository<StudentResultEntity> studentResultRepository)
        {
            _studentResultRepository = studentResultRepository;
        }

        public bool AddStudentResult(AddStudentResultDto addStudentResultDto)
        {
            var studentResultEntity = new StudentResultEntity()
            {
                UserId = addStudentResultDto.UserId,
                QuizId = addStudentResultDto.QuizId,
                Grade = addStudentResultDto.Grade,
                RightAnswers = addStudentResultDto.RightAnswers,
                WrongAnswers = addStudentResultDto.WrongAnswers

            };

            _studentResultRepository.Add(studentResultEntity);
            return true;
        }

        public int DeleteStudentResult(int id)
        {
            var entity = _studentResultRepository.GetById(id);

            if (entity == null)
            {
                return 0;
            }

            try
            {

                _studentResultRepository.Delete(id);
                return 1;
            }

            catch (Exception)

            {
                return -1;



            }

        }

        public List<StudentResultDto> GetAllStudentResult()
        {
            var studentResultEntites = _studentResultRepository.GetAll();

            var studentResultDtos = studentResultEntites.Select(x => new StudentResultDto
            {
                Id = x.Id,
                QuizId = x.QuizId,
                RightAnswers = x.RightAnswers,
                WrongAnswers = x.WrongAnswers,
                Grade=x.Grade,  
                UserId = x.UserId
            }).ToList();

            return studentResultDtos;
        }

        public StudentResultDto GetStudentResult(int id)
        {
            var entity = _studentResultRepository.GetById(id);

            if (entity == null)
            {
                return null;
            }

            var studentResultsDto = new StudentResultDto()

            {
                Id = entity.Id,
                QuizId = entity.QuizId,
                RightAnswers = entity.RightAnswers,
                WrongAnswers = entity.WrongAnswers,
                Grade=entity.Grade,
                UserId = entity.UserId

            };
            return studentResultsDto;
        }

        public int UpdateStudentResult(UpdateStudentResultDto updateStudentResultDto)
        {
            var entity = _studentResultRepository.GetById(updateStudentResultDto.Id);

            if (entity != null)
            {
                entity.QuizId = updateStudentResultDto.QuizId;
                entity.RightAnswers = updateStudentResultDto.RightAnswers;
                entity.WrongAnswers = updateStudentResultDto.WrongAnswers;
                entity.UserId = updateStudentResultDto.UserId;
                try
                {
                    _studentResultRepository.Update(entity);
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }

            }
            else
            {
                return 0;
            }
        }
    }
}

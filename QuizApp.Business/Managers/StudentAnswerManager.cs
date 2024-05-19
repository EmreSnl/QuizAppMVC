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
    public class StudentAnswerManager : IStudentAnswerService
    {
        private readonly IGenericRepository<StudentAnswerEntity> _studentAnswerRepository;

        public StudentAnswerManager(IGenericRepository<StudentAnswerEntity> studentAnswerRepository)
        {
            _studentAnswerRepository = studentAnswerRepository;
        }

        public bool AddStudentAnswer(AddStudentAnswerDto addStudentAnswersDto)
        {


            var studentAnswerEntity = new StudentAnswerEntity()
            {
                UserId = addStudentAnswersDto.StudentId,
                QuestionId = addStudentAnswersDto.QuestionId,
                Answer = addStudentAnswersDto.Answer,
                IsCorrect = addStudentAnswersDto.IsCorrect



            };

            _studentAnswerRepository.Add(studentAnswerEntity);
            return true;
        }


        public StudentAnswerDto GetStudentAnswer(int id)
        {
            var entity = _studentAnswerRepository.GetById(id);

            if (entity == null)
            {
                return null;
            }

            var studentAnswersDto = new StudentAnswerDto()

            {
                Id = entity.Id,
                StudentId = entity.UserId,
                QuestionId = entity.QuestionId,
                Answer = entity.Answer,
                IsCorrect = entity.IsCorrect

            };
            return studentAnswersDto;
        }

        public int UpdateStudentAnswer(UpdateStudentAnswerDto updateStudentAnswerDto)
        {
            var entity = _studentAnswerRepository.GetById(updateStudentAnswerDto.Id);

            if (entity != null)
            {
                entity.QuestionId = updateStudentAnswerDto.QuestionId;
                entity.Answer = updateStudentAnswerDto.Answer;
                entity.UserId =updateStudentAnswerDto.StudentId;
                entity.IsCorrect = updateStudentAnswerDto.IsCorrect;    
                try
                {
                    _studentAnswerRepository.Update(entity);
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

        public int DeleteStudentAnswer(int id)

        {
            var entity = _studentAnswerRepository.GetById(id);

            if (entity == null)
            {
                return 0;
            }

            try
            {

                _studentAnswerRepository.Delete(id);
                return 1;
            }

            catch (Exception)

            {
                return -1;



            }

        }
        public List<StudentAnswerDto> GetAllStudentAnswer()

        {
            var studentAnswerEntites = _studentAnswerRepository.GetAll();

            var studentAnswerDtos = studentAnswerEntites.Select(x => new StudentAnswerDto
            {
                Id = x.Id,
                QuestionId = x.QuestionId,
                Answer = x.Answer,
                IsCorrect = x.IsCorrect,
                StudentId=x.UserId
            }).ToList();

            return studentAnswerDtos;
        }




    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuizController : Controller
    {

        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;

        }

        public IActionResult List()
        {
            var listQuizDtos = _quizService.GetAllQuiz();

            var viewModel = listQuizDtos.Select(x => new QuizListViewModel
            {
                Id = x.Id,
                QuizText = x.QuizText,
                Description = x.Description is not null && x.Description.Length > 20 ? x.Description.Substring(0, 20) + "..." : x.Description
            }).ToList();

            return View(viewModel);
        }

        public IActionResult New()
        {


            return View("Form", new QuizFormViewModel());
        }


        public IActionResult Edit(int id)
        {
            var editQuizDto = _quizService.GetQuiz(id);

            var viewModel = new QuizFormViewModel()
            {
                Id = editQuizDto.Id,
                QuizText = editQuizDto.QuizText,
                Description = editQuizDto.Description
            };

            return View("form", viewModel);

        }


        [HttpPost]
        public IActionResult Save(QuizFormViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View("Form", formData);
            }


            if (formData.Id == 0) // yeni kayıt
            {

                var addQuizDto = new AddQuizDto()
                {
                    QuizText = formData.QuizText.Trim()
                };


                if (formData.Description is not null)
                {
                    addQuizDto.Description = formData.Description.Trim();
                }

                var result = _quizService.AddQuiz(addQuizDto);


                if (result)
                {
                    RedirectToAction("List");

                }
                else
                {
                    ViewBag.ErrorMessage = "This quiz exists already.";
                    return View("Form", formData);
                }

            }
            else
            {
                var updateQuizDto = new UpdateQuizDto()
                {
                    Id = formData.Id,
                    QuizText = formData.QuizText,
                    Description = formData.Description
                };

                _quizService.UpdateQuiz(updateQuizDto);

                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            _quizService.DeleteQuiz(id);
            return RedirectToAction("List");
        }

    }
}

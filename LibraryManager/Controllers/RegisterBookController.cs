using LibraryManager.DataAccess.Dtos;
using LibraryManager.DataAccess.Models;
using LibraryManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class RegisterBookController : Controller
    {
        private readonly IRegisterBookService _registerBookService;

        public RegisterBookController(IRegisterBookService registerBookService)
        {
            _registerBookService = registerBookService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RegisterBook(RegisterBookDto model)
        {
            if(model != null && !string.IsNullOrEmpty(model.BookName))
            {
                var res = await _registerBookService.FormData(model);
                ViewBag.Message = res.Message;

                ModelState.Clear();
                return RedirectToAction("BookList");
            }
            return View(model);
        }

        public async Task<ActionResult> EditBook(string Id)
        {
            var res = await _registerBookService.FetchById(Id);
            if (res == null) return RedirectToAction("BookList");
            else
            {
                RegisterBookDto registerBook = new RegisterBookDto
                {
                    Id = res.Id,
                    BookName = res.BookName,
                    Author = res.Author,
                    Publisher = res.Publisher,
                    PublicationYear = res.PublicationYear,
                };
                return View(registerBook);
            }
        }

        public async Task<ActionResult> BookList()
        {
            return View(await _registerBookService.FetchAll());
        }

        public async Task<ActionResult> DeleteBook(string Id)
        {
            await _registerBookService.Delete(Id);
            return RedirectToAction("BookList");
        }

        public async Task<ActionResult> SetBookStatus(string Id)
        {
            await _registerBookService.SetStatus(Id);
            return RedirectToAction("BookList");
        }
    }
}

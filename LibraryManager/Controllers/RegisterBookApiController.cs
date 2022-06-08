using LibraryManager.DataAccess.Dtos;
using LibraryManager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterBookApiController : ControllerBase
    {
        private readonly IRegisterBookService _registerBookService;

        public RegisterBookApiController(IRegisterBookService registerBookService)
        {
            _registerBookService = registerBookService;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        public async Task<ActionResult> RegisterBook(RegisterBookDto model)
        {
            return Ok(await _registerBookService.FormData(model));
        }
    }
}

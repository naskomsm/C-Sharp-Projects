﻿using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;

namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = DataAccess.Contacts;
            return View(model);
        }
    }
}

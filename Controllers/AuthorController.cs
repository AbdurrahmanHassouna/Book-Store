﻿using Microsoft.AspNetCore.Mvc;

namespace AprilBookStore.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

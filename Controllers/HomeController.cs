<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> master
using NIC.Models;
using System.Diagnostics;

namespace NIC.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "Admin,DHS")]
=======
>>>>>>> master
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

<<<<<<< HEAD
        [AllowAnonymous]
=======
>>>>>>> master
        public IActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        [AllowAnonymous]
=======
>>>>>>> master
        public IActionResult ContactUs()
        {
            return View();
        }
<<<<<<< HEAD

        [AllowAnonymous]
=======
>>>>>>> master
        public IActionResult AboutUs()
        {
            return View();
        }

<<<<<<< HEAD
        [AllowAnonymous]
=======
>>>>>>> master
        public IActionResult Candidates()
        {
            return View();
        }

<<<<<<< HEAD
        public IActionResult Admin()
        {
            return View();
        }

=======
>>>>>>> master
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

<<<<<<< HEAD
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PageDown() {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Success()
        {
            return View();
        }

=======
>>>>>>> master

    }
}
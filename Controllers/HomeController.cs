﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NIC.Models;
using System.Diagnostics;

namespace NIC.Controllers
{
    [Authorize(Roles = "Admin,DHS")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ContactUs()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Candidates()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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


    }
}
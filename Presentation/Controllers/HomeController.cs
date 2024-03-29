﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using DataAccessLayer.Models;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var config = new MapperConfiguration(cgf => 
                cgf.CreateMap<User, UserViewModel>());
            var mapper = new Mapper(config);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
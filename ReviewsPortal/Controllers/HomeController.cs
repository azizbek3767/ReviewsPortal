using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsPortal.Models;
using ReviewsPortal.Services;
using System.Data;
using System.Diagnostics;

namespace ReviewsPortal.Controllers
{
    /*[Authorize(Roles = "admin")]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("azizbekba25@gmail.com", "Тема письма", "Тест письма: тест!");
            return RedirectToAction("Index");
        }
    }
}
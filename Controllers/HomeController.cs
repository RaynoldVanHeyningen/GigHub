using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GigHub.Models;
using GigHub.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GigHubIdentityDbContext _context;

        public HomeController(ILogger<HomeController> logger, GigHubIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var upcomingGigs = _context.Gigs
            .Include(g => g.Artist)
            .Where(g => g.DateTime > DateTime.Now);


            return View(upcomingGigs);
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

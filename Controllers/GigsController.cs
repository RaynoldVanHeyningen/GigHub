using GigHub.Areas.Identity.Data;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly GigHubIdentityDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GigsController(GigHubIdentityDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GigFormViewModel
            {
                Genres = genres,
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = _userManager.GetUserId(User),
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
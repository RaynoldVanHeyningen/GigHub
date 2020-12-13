using GigHub.Areas.Identity.Data;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly GigHubIdentityDbContext _context;

        public GigsController(GigHubIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GigFormViewModel
            {
                Genres = genres,
            };

            return View(viewModel);
        }
    }
}
using GigHub.Areas.Identity.Data;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private GigHubIdentityDbContext _context;

        public GigsController(GigHubIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres =
            };

            return View();
        }
    }
}
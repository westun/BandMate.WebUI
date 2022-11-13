using BandMate.Domain.Core;
using BandMate.MusicCatalog.Persistence;
using BandMate.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BandMate.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IArtistRepository artistRepository;

        public HomeController(ILogger<HomeController> logger,
            IUnitOfWork unitOfWork,
            IArtistRepository artistRepository)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.artistRepository = artistRepository;
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
    }
}
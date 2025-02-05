using System.Diagnostics;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Web.Models;
using Otaghche.Web.ViewModels;

namespace Otaghche.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAllByFilterAsync(includes : h => h.Amenities);

            HomeVM homeVM = new()
            {
                 HotelsList = hotels,
                 CheckInDate = DateOnly.FromDateTime(DateTime.Now),
                 Nights = 1
            };

            return View(homeVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

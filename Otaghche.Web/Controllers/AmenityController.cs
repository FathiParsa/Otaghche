using Microsoft.AspNetCore.Mvc;
using Otaghche.Appliaction.Common.Interfaces;

namespace Otaghche.Web.Controllers
{
   
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var amenities = await _unitOfWork.AmenityRepository.GetAllAsync();
            return View(amenities);   
        }
    }
}

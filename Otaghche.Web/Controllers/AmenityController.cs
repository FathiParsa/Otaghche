using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Web.ViewModels;

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
            var amenities = await _unitOfWork.AmenityRepository.GetAllByFilterAsync(includes: u => u.Hotel);
            return View(amenities);
        }

        public async Task<IActionResult> Create()
        {
            AmenityVM amenityVM = new()
            {
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(amenityVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AmenityVM amenityVM)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.AmenityRepository.AddAsync(amenityVM.Amenity);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "امکان رفاهی جدید اضافه شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطا";

            amenityVM.HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(amenityVM);
        }

        public async Task<IActionResult> Update(int amenityId)
        {
            var amenity = await _unitOfWork.AmenityRepository.GetFirstByFilterAsync(a => a.Id == amenityId);

            AmenityVM amenityVM = new()
            {
                Amenity = amenity,
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(amenityVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AmenityVM amenityVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AmenityRepository.Update(amenityVM.Amenity);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "امکان رفاهی با موفقیت بروزرسانی شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطا";

            amenityVM.HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(amenityVM);
        }

        public async Task<IActionResult> Delete(int amenityId)
        {
            var amenity = await _unitOfWork.AmenityRepository.GetFirstByFilterAsync(a => a.Id == amenityId);

            AmenityVM amenityVM = new()
            {
                Amenity = amenity,
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(amenityVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AmenityVM amenityVM)
        {
            var amenity = await _unitOfWork.AmenityRepository.GetFirstByFilterAsync(a => a.Id == amenityVM.Amenity.Id);

            if (amenity != null)
            {
                _unitOfWork.AmenityRepository.Delete(amenity);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "امکان رفاهی حذف شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطا";

            amenityVM.Amenity = amenity;

            amenityVM.HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(amenityVM);
        }
    }
}





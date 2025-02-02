using Microsoft.AspNetCore.Mvc;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Domain.Entities;


namespace Otaghche.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAllAsync();
            return View(hotels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.HotelRepository.AddAsync(hotel);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "هتل جدید با موفقیت اضافه شد";
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public async Task<IActionResult> Update(int hotelId)
        {
            Hotel? hotel = await _unitOfWork.HotelRepository.GetFirstByFilterAsync(h => h.Id == hotelId);
            if (hotel == null) 
            { 
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.HotelRepository.Update(hotel);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "هتل بروزرسانی شد";
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public async Task<IActionResult> Delete(int hotelId)
        {
            var hotel = await _unitOfWork.HotelRepository.GetFirstByFilterAsync(h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Hotel hotel)
        {
            Hotel? correctHotel = await _unitOfWork.HotelRepository.GetFirstByFilterAsync(h => h.Id == hotel.Id);

            if (correctHotel == null)
            { 
                return NotFound();
            }

            _unitOfWork.HotelRepository.Delete(correctHotel);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "هتل حذف شد";
            return RedirectToAction("Index");
        }
    }
}

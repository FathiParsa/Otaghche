using Microsoft.AspNetCore.Mvc;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Domain.Entities;


namespace Otaghche.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
                if (hotel.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\HotelImages");

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }

                    hotel.ImageUrl = @"\Images\HotelImages\" + fileName;
                }
                else
                {
                    hotel.ImageUrl = "https://placehold.co/600x400";
                }

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
                if (hotel.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\HotelImages");

                    if (!string.IsNullOrEmpty(hotel.ImageUrl))
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, hotel.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }

                    hotel.ImageUrl = @"\Images\HotelImages\" + fileName;
                }

                _unitOfWork.HotelRepository.Update(hotel);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "هتل بروزرسانی شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطا";
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

            if (!string.IsNullOrEmpty(correctHotel.ImageUrl))
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, correctHotel.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _unitOfWork.HotelRepository.Delete(correctHotel);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "هتل حذف شد";
            return RedirectToAction("Index");
        }
    }
}

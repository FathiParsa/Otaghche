using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Infrastructure.Data;
using Otaghche.Web.ViewModels;

namespace Otaghche.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationDbContext _context { get; set; }
        public RoomController(ApplicationDbContext context , IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllByFilterAsync(includes: h => h.Hotel);
            return View(rooms);
        }

        public async Task<IActionResult> Create()
        {
            RoomVM? roomVM = new()
            {
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(roomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomVM roomVM)
        {
            bool IsExists = await _unitOfWork.RoomRepository.AnyAsync(u => u.RoomNumber == roomVM.Room.RoomNumber);

            if (ModelState.IsValid && !IsExists)
            {
                await _unitOfWork.RoomRepository.AddAsync(roomVM.Room);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "اتاق با موفقیت اضافه شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "شماره اتاق از قبل موجود است";

            roomVM.HotelsList = _unitOfWork.HotelRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(roomVM);
        }

        public async Task<IActionResult> Update(int roomNumber)
        {
            var room = await _unitOfWork.RoomRepository.GetFirstByFilterAsync(u => u.RoomNumber == roomNumber);

            RoomVM roomVM = new()
            {
                Room = room,
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select( u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(roomVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(RoomVM roomVM)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.RoomRepository.Update(roomVM.Room);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "اتاق با موفقیت بروزرسانی شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطایی رخ داده است";

            roomVM.HotelsList = _unitOfWork.HotelRepository.GetAll().Select( u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(roomVM);
        }

        public async Task<IActionResult> Delete(int roomNumber)
        {
            var room = await _unitOfWork.RoomRepository.GetFirstByFilterAsync(u => u.RoomNumber == roomNumber);
            RoomVM roomVM = new()
            {
                Room = room,
                HotelsList = _unitOfWork.HotelRepository.GetAll().Select( u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(roomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoomVM? roomVM)
        {
            var room = await _unitOfWork.RoomRepository.GetFirstByFilterAsync(u => u.RoomNumber == roomVM.Room.RoomNumber);
            if (room != null)
            {
                _unitOfWork.RoomRepository.Delete(room);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "اتاق حذف شد";
                return RedirectToAction("Index");
            }
            return View(roomVM);
        }
    }
}

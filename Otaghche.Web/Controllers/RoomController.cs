using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otaghche.Infrastructure.Data;
using Otaghche.Web.ViewModels;

namespace Otaghche.Web.Controllers
{
    public class RoomController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.Include(h => h.Hotel).ToListAsync();
            return View(rooms);
        }

        public async Task<IActionResult> Create()
        {
            RoomVM? roomVM = new()
            {
                HotelsList = _context.Hotels.ToList().Select( u => new SelectListItem
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
            bool IsExists = await _context.Rooms.AnyAsync(u => u.RoomNumber == roomVM.Room.RoomNumber);

            if (ModelState.IsValid && !IsExists)
            {
                await _context.Rooms.AddAsync(roomVM.Room);
                await _context.SaveChangesAsync();
                TempData["success"] = "اتاق با موفقیت اضافه شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "شماره اتاق از قبل موجود است";

            roomVM.HotelsList = _context.Hotels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(roomVM);
        }

        public async Task<IActionResult> Update(int roomNumber)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(u => u.RoomNumber == roomNumber);

            RoomVM roomVM = new()
            {
                Room = room,
                HotelsList = _context.Hotels.ToList().Select( u => new SelectListItem
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
                _context.Rooms.Update(roomVM.Room);
                await _context.SaveChangesAsync();
                TempData["success"] = "اتاق با موفقیت بروزرسانی شد";
                return RedirectToAction("Index");
            }

            TempData["error"] = "خطایی رخ داده است";

            roomVM.HotelsList = _context.Hotels.ToList().Select( u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(roomVM);
        }

        public async Task<IActionResult> Delete(int roomNumber)
        {
            var room = _context.Rooms.FirstOrDefault(u => u.RoomNumber == roomNumber);
            RoomVM roomVM = new()
            {
                Room = room,
                HotelsList = _context.Hotels.ToList().Select( u => new SelectListItem
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
            var room = _context.Rooms.FirstOrDefault(u => u.RoomNumber == roomVM.Room.RoomNumber);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                TempData["success"] = "اتاق حذف شد";
                return RedirectToAction("Index");
            }

            return View(roomVM);
        }
    }
}

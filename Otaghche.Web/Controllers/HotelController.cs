using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otaghche.Domain.Entities;
using Otaghche.Infrastructure.Data;

namespace Otaghche.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _context.Hotels.ToListAsync();
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
                await _context.Hotels.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public async Task<IActionResult> Update(int hotelId)
        {
            Hotel? hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == hotelId);
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
                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public async Task<IActionResult> Delete(int hotelId)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync( h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Hotel hotel)
        {
            Hotel? correctHotel = await _context.Hotels.FirstOrDefaultAsync( h => h.Id == hotel.Id);

            if (correctHotel == null)
            { 
                return NotFound();
            }
            
            _context.Hotels.Remove(correctHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

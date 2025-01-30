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
                await _context.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
    }
}

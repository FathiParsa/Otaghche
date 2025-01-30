using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}

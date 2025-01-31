using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otaghche.Infrastructure.Data;

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
    }
}

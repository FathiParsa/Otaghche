using Microsoft.AspNetCore.Mvc.Rendering;
using Otaghche.Domain.Entities;

namespace Otaghche.Web.ViewModels
{
    public class RoomVM
    {
        public Room? Room { get; set; }
        public IEnumerable<SelectListItem>? RoomsList { get; set; }
    }
}

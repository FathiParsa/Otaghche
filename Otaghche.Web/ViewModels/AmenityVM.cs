using Microsoft.AspNetCore.Mvc.Rendering;
using Otaghche.Domain.Entities;

namespace Otaghche.Web.ViewModels
{
    public class AmenityVM
    {
        public Amenity? Amenity { get; set; }

        public IEnumerable<SelectListItem>? HotelsList { get; set; }
    }
}

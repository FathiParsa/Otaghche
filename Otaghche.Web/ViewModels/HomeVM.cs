using Otaghche.Domain.Entities;

namespace Otaghche.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Hotel>? HotelsList { get; set; }
        public DateOnly CheckInDate { get; set; }       
        public DateOnly CheckOutDate { get; set; }
        public int Nights { get; set; }
    }
}

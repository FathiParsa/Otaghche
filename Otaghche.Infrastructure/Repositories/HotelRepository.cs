using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Domain.Entities;
using Otaghche.Infrastructure.Data;

namespace Otaghche.Infrastructure.Repositories
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
        
        }
    }
}

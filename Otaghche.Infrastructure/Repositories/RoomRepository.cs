using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Domain.Entities;
using Otaghche.Infrastructure.Data;

namespace Otaghche.Infrastructure.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

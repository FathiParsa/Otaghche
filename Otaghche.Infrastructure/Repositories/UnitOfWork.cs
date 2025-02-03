using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Infrastructure.Data;

namespace Otaghche.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IHotelRepository HotelRepository { get; private set; }

        public IRoomRepository RoomRepository { get; private set; }

        public IAmenityRepository AmenityRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context ,
            IHotelRepository hotelRepository ,
            IRoomRepository roomRepository ,
            IAmenityRepository amenityRepository)
        {
            _context = context;
            HotelRepository = hotelRepository;
            RoomRepository = roomRepository;
            AmenityRepository = amenityRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

namespace Otaghche.Appliaction.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository HotelRepository { get; }
        IRoomRepository RoomRepository { get; }

        Task SaveAsync();
    }
}

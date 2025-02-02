using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otaghche.Appliaction.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository HotelRepository { get; }
        IRoomRepository RoomRepository { get; }

        Task SaveAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Domain.Entities;
using Otaghche.Infrastructure.Data;

namespace Otaghche.Infrastructure.Repositories
{
    public class AmenityRepository : Repository<Amenity> , IAmenityRepository
    { 
        public AmenityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

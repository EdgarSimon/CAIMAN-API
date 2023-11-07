using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Destino>> GetAsync(Object parameters);
        Task<int> InsertAsync(DestinationInsertDto data);
    }
}

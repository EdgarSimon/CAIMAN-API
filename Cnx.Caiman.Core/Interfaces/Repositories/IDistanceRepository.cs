using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.TariffDestinationProduct;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IDistanceRepository
    {
        Task<IEnumerable<TarifaConsultarDestinoProducto>> TariffConsultOriginProductAsync(Object parameters);
        Task<IEnumerable<TarifaConsultarDestinoProducto>> TariffConsultDestinationProductAsync(Object parameters);
        Task<int> UpdateAsync(DistanceUpdateDto data);

    }
}
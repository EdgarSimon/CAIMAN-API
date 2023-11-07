using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDbContext dbContext;

        public CustomerRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Destino>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<Destino,
                Cedi,SubZona, Destino>("[dbo].[Evo_ClienteListar]", 
                map: (destino, cedi, subzona) => {
                    destino.Cedi = cedi;
                    destino.SubZona = subzona;
                    return destino;
                },
                splitOn: "IdCedi, SubZona",
                parameters: parameters);
        }

        public async Task<int> InsertAsync(DestinationInsertDto data)
        {
            try
            {
                var parameters = new {
                    nombre = data.Nombre,
                    zona = data.Zona,
                    manana = data.Manana,
                    tarde = data.Tarde,
                    noche = data.Noche,
                    idsubzona = data.Idsubzona,
                    clavesicadi = data.Clavesicadi,
                    claveSit = data.ClaveSit,
                    AutoAbasto = data.AutoAbasto,
                    vc20usuario = data.Vc20usuario,
                    vc25NombreCorto = data.Vc25NombreCorto
                };
                return await this.dbContext.ExecuteAsync("[dbo].[ClienteInsertar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

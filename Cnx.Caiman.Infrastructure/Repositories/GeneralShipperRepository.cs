using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class GeneralShipperRepository : IGeneralShipperRepository
    {
        private readonly IDbContext dbContext;

        public GeneralShipperRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<int> DeleteAsync(int id, string username)
        {
            try 
            {
                var parameters = new {
                    id = id,
                    vc20Usuario = username,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TransportistaGeneralEliminar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<dynamic> GetAsync(Object parameters)
        {
            IEnumerable<TransportistaGeneral> shipperCollaction = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ListarTransportistaGeneral]", parameters: parameters))
            {
                shipperCollaction = await multiple.ReadAsync<TransportistaGeneral>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            { 
                records = shipperCollaction,
                count = totalCount
            };
        }

        public TransportistaGeneral GetShipperByGeneralShipperAsync(ShipperByGeneralShipperDto data)
        {
            TransportistaGeneral transportistasGeneral;
            IEnumerable<Transportista> transportistas;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[ObtenerTransportistasPorTransportistaGeneral]", parameters: (Object)data))
            {
                transportistas = multiple.Read<Transportista>().ToList();
                transportistasGeneral = multiple.Read<TransportistaGeneral>().FirstOrDefault();
            }

            if(transportistasGeneral != null)
            {
                foreach(var lote in transportistas)
                {
                    transportistasGeneral.TransportistaLotes.Add(lote);
                }
            }

            return transportistasGeneral;
        }

        public async Task<int> InsertAsync(GeneralShipperInsertDto data)
        {
            try 
            {
                return await this.dbContext.ExecuteScalarAsync<int>("[dbo].[TransportistaGeneralInsertar]", (Object)data);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(int idTransportista, GeneralShipperUpdateDto data)
        {
            try 
            {
                var parameters = new {
                    transportista = idTransportista,
                    nombre = data.Nombre,
                    vcSAP = data.VcSAP,
                    vc20Usuario = data.Vc20usuario,
                    bActivo = data.BActivo
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TransportistaGeneralActualizar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportistaGeneral>> GetShipperAvailableAsync(int idZone)
        {
            try 
            {
                var parameters = new {
                    idzona = idZone,
                };
                return await this.dbContext.QueryAsync<TransportistaGeneral>("[dbo].[ListarTransportistasGeneralesDisponiblesParaAgregar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
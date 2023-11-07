using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.OrdenCapacity;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ConcretRepository: IConcretRepository
    {
        private readonly IDbContext dbContext;

        public ConcretRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Demanda>> GetAsync(Object parameters)
        {
            var result = await this.dbContext.QueryAsync<Demanda, Destino, RelUso, Producto, Demanda>("[dbo].[Evo_DemandaListarTodo]",
                map: (Demanda, destino, RelUso, producto) =>
                {
                    Demanda.Destino = destino;
                    Demanda.RelUso = RelUso;
                    Demanda.Producto = producto;

                    return Demanda;
                },
                splitOn: "IdDestino, IdUso, IdProducto",
                parameters);

            return result.ToList();
        }

        public async Task<int> ShowPhotoAsync(int idzone, DateTime date)
        {

            var parameters = new
            {
                dtfecha = date.ToString("yyyy-MM-dd"),
                idzona = idzone
            };
            var result = await this.dbContext.QueryAsync<int>("[dbo].[CrearFotoDemandaMostrar]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<List<CapacidadDeOrden>> OrdenVerifyCapacityAsync(int idzone, DateTime date, int capacity)
        {

            var parameters = new
            {
                idZona = idzone,
                icapacidad = capacity,
                dtfecha = date.ToString("yyyy-MM-dd")
            };
            var result = await this.dbContext.QueryAsync<CapacidadDeOrden>("[dbo].[OrdenConfCapacidadVerificar]", parameters: parameters);

            return result.ToList();
        }

        public async Task<int> UpdateAsync(DemandUpdateDto model)
        { 
            var parameters = new {
                iPrioridad1 = model.iPrioridad1,
                iPrioridad2 = model.iPrioridad2,
                iPrioridad3= model.iPrioridad3,
                idDemanda = model.idDemanda,
                Demanda = model.Demanda,
                vcObservaciones = model.vcObservaciones,
                Vc20Usuario = model.Vc20Usuario
            };
            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_DemandaActualizar]", parameters: parameters);

            return result;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetSicadiAsync(SicadiDemandDto model)
        {

            var result = await this.dbContext.QueryAsync<KeyValuePair<string, string>>("[dbo].[CapacidadTraerDeSicadiInfoPrevia]", 
                                                                                                parameters: new { idzona = model.IdZone});

            return result;
        }

        public async Task<int> UpdateSicadiAsync(string origins, string products,DateTime date)
        {
            var parameters = new
            {
                origenes = origins,
                productos = products,
                fechaIni = date.ToString("yyyy-MM-dd"),
                fechaFin = date.ToString("yyyy-MM-dd")
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[IntGetDetPedidoDemanda]", parameters: parameters);

            return result;
        }

    }
}

using System.Collections;
using System;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using Cnx.Caiman.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Cnx.Caiman.Core.DTOs.Zone;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly IDbContext dbContext;

        public ZoneRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<Zona>> ListAsync(Object parameters)
        {

            return await this.dbContext.QueryAsync<Zona, Medicion, Zona>("[dbo].[Evo_ZonaListar]",
                                                                   map: (zona, medicion) =>
                                                                   {
                                                                       zona.Medicion = medicion;

                                                                       return zona;
                                                                   },
                                                                   splitOn: "idMedicion",
                                                                   parameters: parameters);

        }

        public async Task<Zona> ListProfileZoneAsync(int iduser, int idzone)
        {
            var parameters = new { idusuario = iduser, idzona = idzone };

            var result = await this.dbContext.QueryAsync<Zona, Medicion, Zona>("[dbo].[Evo_PerfilListarZona]",
                                                                   map: (zona, medicion) =>
                                                                   {
                                                                       zona.Medicion = medicion;

                                                                       return zona;
                                                                   },
                                                                   splitOn: "idMedicion",
                                                                   parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<List<Zona>> ProfileNameAsync(int idzone)
        {
            var parameters = new { idZona = idzone };

            var result = await this.dbContext.QueryAsync<Zona, Medicion, Zona>("[dbo].[Evo_ZonaListarNombre]",
                                                                   map: (zona, medicion) =>
                                                                   {
                                                                       zona.Medicion = medicion;

                                                                       return zona;
                                                                   },
                                                                   splitOn: "idMedicion",
                                                                   parameters: parameters);

            return result.ToList();
        }

        public async Task<List<Medicion>> MeasuringListAsync()
        {
            var result = await this.dbContext.QueryAsync<Medicion>("[dbo].[Evo_ZonaListarMedicion]");
            return result.ToList();
        }


        public async Task<int> InsertAsync(ZoneInsertDto zoneModel)
        {
            var parameters = new
            {
                vc50Nombre = zoneModel.Vc50Nombre,
                unidadesporviaje = zoneModel.NUnidadesPorViaje,
                idmedicion = zoneModel.IdMedicion,
                manejatiempos = zoneModel.BManejaTiempos,
                tarifaunica = zoneModel.BTarifaUnica,
                granel = zoneModel.BGranel,
                sit = zoneModel.BSit,
                OptimizadorFull = zoneModel.BOptimizadorFull,
                Oferta2 = zoneModel.BOferta2,
                vc20Usuario = zoneModel.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_ZonaInsertar2]", parameters: parameters);

            return result;
        }

        public async Task<int> UpdateAsync(int idZone, ZoneInsertDto zoneModel)
        {
            var parameters = new
            {
                idZona = idZone,
                vc50Nombre = zoneModel.Vc50Nombre,
                unidadesporviaje = zoneModel.NUnidadesPorViaje,
                idmedicion = zoneModel.IdMedicion,
                manejatiempos = zoneModel.BManejaTiempos,
                tarifaunica = zoneModel.BTarifaUnica,
                granel = zoneModel.BGranel,
                sit = zoneModel.BSit,
                OptimizadorFull = zoneModel.BOptimizadorFull,
                Oferta2 = zoneModel.BOferta2,
                vc20Usuario = zoneModel.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[ZonaActualizar2]", parameters: parameters);

            return result;
        }

        public async Task<int> DeleteAsync(int idzone)
        {
            var parameters = new { idZona = idzone };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[ZonaEliminar]", parameters: parameters);

            return result;
        }

        public async Task<List<Zona>> ListByUserAsync(int iduser)
        {
            var parameters = new
            {
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<Zona>("[dbo].[Evo_UsuarioListarZonasRelacionadas]", parameters: parameters);

            return result.ToList();
        }


    }
}
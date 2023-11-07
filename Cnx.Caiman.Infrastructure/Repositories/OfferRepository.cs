using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IDbContext dbContext;
        public OfferRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> GetOfferAsync(int idZone)
        {

            var parameters = new
            {
                p_idZona = idZone
            };
            var result = await this.dbContext.QueryAsync<bool>("[dbo].[spZonaBuscaOferta2]", parameters: parameters);

            return result.FirstOrDefault();
        }
        //public async Task<IEnumerable<OfertaResult>> GetOfferListAsyc(int idzone, DateTime date, int user)
        //{

        //    var parameters = new
        //    {
        //        dtFecha = date.ToString("yyyy-MM-dd"),
        //        idZona = idzone,
        //        idUsuario = user

        //    };
        //    var result = await this.dbContext.QueryAsync<OfertaResult>("[dbo].[Evo_OfertaListarTodo]", parameters: parameters);

        //    return result;
        //}


        public async Task<dynamic> GetOfferListAsyc(Object parameters)
        {
            IEnumerable<OfertaResult> userCollection = null;
            int totalCount = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_OfertaListarTodo]", parameters: parameters))
            {
                userCollection = await multiple.ReadAsync<OfertaResult>();
                totalCount = multiple.ReadSingle<int>();
            }

            return new
            {
                records = userCollection,
                count = totalCount
            };
        }
        
        public async Task<dynamic> GetOfferList2Asyc(Object parameters)
        {
            IEnumerable<OfertaResult> userCollection = null;
            int totalCount = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_OfertaListarTodo2]", parameters: parameters))
            {
                userCollection = await multiple.ReadAsync<OfertaResult>();
                totalCount = multiple.ReadSingle<int>();
            }

            return new
            {
                records = userCollection,
                count = totalCount
            };
        }

        public async Task<int> ShowPhotoAsync(int idzone, DateTime date)
        {

            var parameters = new
            {
                dtfecha = date.ToString("yyyy-MM-dd"),
                idzona = idzone
            };
            var result = await this.dbContext.QueryAsync<int>("[dbo].[CrearFotoOfertaMostrar]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<bool> OrdenVerifyCapacityAsync(int idzone, DateTime date, int capacity )
        {

            var parameters = new
            {
                idZona = idzone,
                icapacidad = capacity,
                dtfecha = date.ToString("yyyy-MM-dd")
            };
            var result = await this.dbContext.QueryAsync<int>("[dbo].[OrdenConfCapacidadVerificar]", parameters: parameters);

            return result.Any();
        }

        public async Task<ValidaOrdenResult> CreatePhotoAsync(int idzone, DateTime date, int capacity)
        {

            var parameters = new
            {
                idZona = idzone,
                icapacidad = capacity,
                dtfecha = date.ToString("yyyy-MM-dd")
            };
            var result = await this.dbContext.QueryAsync<ValidaOrdenResult>("[dbo].[Evo_OrdenConfCapacidadFlagCrearFoto]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<KeyValuePair<InfoCapacidadesResult, List<InfoCapacidadesDetalleResult>>> InfoCapacityAsync(int idzone, DateTime date)
        {

            var parameters = new
            {
                idZona = idzone,
                dtfecha = date.ToString("yyyy-MM-dd")
            };

            InfoCapacidadesResult result = null;
            List<InfoCapacidadesDetalleResult> resultdetails = null;


            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_InfoCapacidades]", parameters: parameters))
            {
                result = (await multiple.ReadAsync<InfoCapacidadesResult>()).FirstOrDefault();
                resultdetails = (await multiple.ReadAsync<InfoCapacidadesDetalleResult>()).ToList();
            }

            var ResultDetalils = new KeyValuePair<InfoCapacidadesResult, List<InfoCapacidadesDetalleResult>>
                (
                result,
                resultdetails
                );

            return ResultDetalils;
        }


        public async Task<int> UpdateOfferAsync(OfferUpdateDto model)
        {
            var parameters = new
            {
                idOferta = model.IdOferta,
                Oferta = model.Oferta,
                vcObservaciones = model.Observaciones,
                usuario = model.Vc20Usuario,
                fecha = model.Fecha.ToString("yyyy-MM-dd")
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[OfertaActualizar]", parameters: parameters);

            return result;
        }

        public async Task<int> InsertOfferAsync(OfferInsertDto model, int element)
        {
            var parameters = new
            {
                elemento = element,
                idzona = model.idzone,
                fecha = model.date.ToString("yyyy-MM-dd"),
                vc20Usuario = model.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[FotoInsertar]", parameters: parameters);

            return result;
        }

        public async Task<int> UpdateOfferTwoAsync(OfferUpdateTwoDto model)
        {
            var parameters = new
            {
                idOferta = model.IdOferta,
                OfertaManiana = model.OfertaManiana,
                OfertaTarde = model.OfertaTarde,
                OfertaNoche = model.OfertaNoche,
                vcObservaciones = model.Observaciones,
                usuario = model.VcUsuario,
                fecha = model.Fecha.ToString("yyyy-MM-dd")
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[OfertaActualizar2]", parameters: parameters);

            return result;
        }
    }
}

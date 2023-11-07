using Cnx.Caiman.Core.DTOs.Agreement;
using Cnx.Caiman.Core.DTOs.Hour;
using Cnx.Caiman.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IAgreementRepository
    {
        Task<IEnumerable<RestriccionTipo>> ByTypeAsync();
        Task<IEnumerable<Perfil>> ProfileListAsync();
        Task<IEnumerable<ConvenioFrecuencia>> FrequencyAsync();
        Task<EsqPivPron> FindInfoAsync(FindInfoDto model);
        Task<Restriccion> RestrictionInfoAsync(int idrestriction);
        Task<dynamic> ListSearchAsync(Object arguments);
        Task<dynamic> GetByDailyPlanAsync(Object parameters);
        Task<int> InfoAsync(int idzone);
        Task<int> GetTIDAsync(string description);
        Task<int> DeleteTransacAsync(long TID);
        Task<int> DeleteAsync(int idagreement);
        Task<int> InsertAsync(AgreementSaveDto agreement);
        Task<int> UpdateAsync(AgreementSaveDto agreement);
        Task<int> UpdateDpAsync(AgreementDailyPlanDto model);
        Task<IEnumerable<Horario>> GetRestrictionAsync(int idZona, long tid, string search);
        Task<IEnumerable<Horario>> GetRestrictionOnetoOneAsync(int idZona, long tid, string search);
        Task<int> InsertRestrictionAsync(HourRestrictionDto model);
    }
}

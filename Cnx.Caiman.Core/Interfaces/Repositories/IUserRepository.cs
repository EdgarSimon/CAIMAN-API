using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.User;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {        
        Task InsertAsync(UserDto model);

        Task UpdateAsync(UserDto model);

        Task UpdateInfoAsync(UserDto model);

        Task DeleteAsync(int idUser);

        Task<dynamic> LoginAsync(string username, string password);

        Task<dynamic> FindByZoneAsync(Object parameters);

        Task<Usuario> GetInfoAsync(int idUser);        

        Task<Perfil> GetProfileAsync(int idZone, int idUser);

        Task<List<UsuarioZona>> GetUserZoneAsync(int user, int userUpdate);

        Task UpdateUserZoneAsync(int iduser, int idzone, int acces);

        Task<List<UsuarioPerfil>> GetUserProfileAsync(int idzone, int iduser);
        Task UpdateUserProfileAsync(UserProfileUpdateDto model);

        Task<List<Pagina>> GetPagePermitAsync(int idzone, int iduser, int option);
        Task UpdateUserPermitAsync(UserPermitUpdateDto model, UserchekUpdateDto detail);

        Task<List<KeyValuePair<string, int>>> GetByPlanDailyAsync(int idzone, int iduser);
        Task UpdatePlanDailyAsync(UserPlanDailyUpdateDto model);
        Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyAgreggentAsync(int idzone, int iduser);
        Task UpdateAgreggentAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateAgreggentAllAsync(UserPermisionPlanDailyAllDto model);
        Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyConcretAsync(int idzone, int iduser);
        Task UpdateConcretAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateConcretAllAsync(UserPermisionPlanDailyAllDto model);
        Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyShipperAsync(int idzone, int iduser);
        Task UpdateShipperAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateShipperAllAsync(UserPermisionPlanDailyAllDto model);
        Task<List<KeyValuePair<string, int>>> GetByMonitorAsync(int idzone, int iduser);
        Task<List<RelUsuarioPermisoAdmin>> GetMonitorAgreggentAsync(int idzone, int iduser);
        Task UpdateMonitorAgreggentAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateMonitorAgreggentAllAsync(UserPermisionPlanDailyAllDto model);

        Task<List<RelUsuarioPermisoAdmin>> GetMonitorConcretAsync(int idzone, int iduser);
        Task UpdateMonitorConcretAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateMonitorConcretAllAsync(UserPermisionPlanDailyAllDto model);

        Task<List<RelUsuarioPermisoAdmin>> GetMonitorShipperAsync(int idzone, int iduser);
        Task UpdateMonitorShipperAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check);
        Task UpdateMonitorShipperAllAsync(UserPermisionPlanDailyAllDto model);
        Task UpdateMonitorAsync(UserSecurityManagementDto model);
        Task UserClonAsync(UserClonDto model);
        Task<IEnumerable<RelUsuarioPermiso>> PagePermissionsAsync(int idZone, int idUser, int page);
        Task<dynamic> MenuPermitAsync(int IdUser, int IdZone);
        Task UpdateEmailAsync(int idUser, string email);
        Task<dynamic> GetUserForMailAsync(string email);
    }
}
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.User;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IUserService
    {        
        Task InsertAsync(UserDto userDTO);

        Task UpdateAsync(UserDto userDTO);

        Task UpdateInfoAsync(UserDto userDTO);
        
        Task DeleteAsync(int idUser);

        Task<ApiResponse<UserLoginResponseDto>> LoginAsync(string username, string password, string email);

        Task<ApiResponse<IEnumerable<UserDto>>> FindByZoneAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<UserDto>>> getFindByZoneAsync(PaginationQuery filter, Nullable<int> idZone);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);

        Task<ApiResponse<UserDto>> GetInfoAsync(int idUser);        

        Task<ApiResponse<ProfileDto>> GetProfileAsync(int idZone, int idUser);

        Task<ApiResponse<List<UserZoneDto>>> GetUserZoneAsync(int idUser, int idUserUpdate);
        Task UpdateUserZoneAsync(UserZoneUpdateDto model);
        Task<ApiResponse<List<UserProfileDto>>> GetByProfileAsync(int idZone, int idUser);
        Task UpdateUserProfileAsync(UserProfileUpdateDto model);
        Task<ApiResponse<List<UserPermitDto>>> GetPagePermitAsync(int idZone, int idUser, int option);
        Task UpdateUserPermitAsync(UserPermitUpdateDto model);
        Task<ApiResponse<List<KeyValuePair<string, int>>>> GetByPlanDailyAsync(int idZone, int idUser);
        Task UpdatePlanDailyAsync(UserPlanDailyUpdateDto model);
        Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPermisionAgreggentAsync(int idzone, int iduser, int module);
        Task UpdateAgreggentAsync(UserPermisionPlanDailyDto model);
        Task UpdateAgreggentAllAsync(UserPermisionPlanDailyAllDto model);
        Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPlanDailyConcretAsync(int idzone, int iduser, int module);
        Task UpdateConcretAsync(UserPermisionPlanDailyDto model);
        Task UpdateConcretAllAsync(UserPermisionPlanDailyAllDto model);
        Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPlanDailyShipperAsync(int idzone, int iduser, int module);
        Task UpdateShipperAsync(UserPermisionPlanDailyDto model);
        Task UpdateShipperAllAsync(UserPermisionPlanDailyAllDto model);
        Task<ApiResponse<List<KeyValuePair<string, int>>>> GetByMonitorAsync(int idZone, int idUser);
        Task UpdateMonitorAsync(UserSecurityManagementDto model);
        Task UserClonAsync(UserClonDto model);
        Task<ApiResponse<IEnumerable<RelUserPermissionsDto>>> PagePermissionsAsync(int idZone, int idUser, int page);
        Task<ApiResponse<UserLoginResponseDto>> getUserMailAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.User;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using Dapper;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        public async Task InsertAsync(UserDto model)
        {
            var parameters = new
            {
                vc20ClaveUsuario = model.Vc20ClaveUsuario,
                vc80NombreUsuario = model.Vc80NombreUsuario,
                iDia = model.IDia,
                vc50Contrasena = model.Vc50Contrasena,
                tiAdministrador = model.BAdministrador,
                iMensual =model.BMensual,
                IdZona = model.IdZona,
                vc20UsuarioCreacion = model.Vc20UsuarioCreacion,
                vc20UsuarioActualizacion = model.Vc20UsuarioActualizacion,
                email = model.Vc50Correo,
                dtCreacion = model.DtCreacion
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_UsuarioInsertar2]", parameters: parameters);
        }

        public async Task UpdateAsync(UserDto model)
        {
            var parameters = new
            {
                IdUsuario = model.IdUserUpdate,
                vc20ClaveUsuario = model.Vc20ClaveUsuario,
                vc80NombreUsuario = model.Vc80NombreUsuario,
                iDia = model.IDia,
                IdZona = model.IdZona,
                tiAdministrador = model.BAdministrador,
                iMensual = model.BMensual,
                vc20UsuarioActualizacion = model.Vc20UsuarioActualizacion,
                email = model.Vc50Correo
            };

            await this.dbContext.ExecuteAsync("[dbo].[UsuarioActualizar2]", parameters: parameters);
        }

        public async Task UpdateInfoAsync(UserDto model)
        {
            var parameters = new
            {
                IdUsuario = model.IdUsuario,
                vc20ClaveUsuario = model.Vc20ClaveUsuario,
                idzona = model.IdZona,
                vc80NombreUsuario = model.Vc80NombreUsuario,
                email = model.Vc50Correo
            };

            await this.dbContext.ExecuteAsync("[dbo].[UsuarioActualizarInformacionPersonal]", parameters: parameters);
        }

        public async Task DeleteAsync(int idUser)
        {
            var parameters = new
            {
                idUsuario = idUser
            };

            await this.dbContext.ExecuteAsync("[dbo].[UsuarioEliminar]", parameters: parameters);
        }        

        public async Task<dynamic> LoginAsync(string username, string password)
        {
            var parameters = new
            {
                vc20ClaveUsuario = username
            };

            Usuario usuario = null;
            IEnumerable<Zona> zonas = null;
            IEnumerable<Medicion> mediciones = null;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ListaUsuario]", parameters: parameters))
            {
                var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var field = typeof(SqlMapper.GridReader).GetField("reader", bindFlags);
                var DataValues = (SqlDataReader)field?.GetValue(multiple);

                if (DataValues!= null && DataValues.HasRows)
                {
                    usuario = await multiple.ReadSingleAsync<Usuario>();
                    zonas = await multiple.ReadAsync<Zona>();
                    mediciones = await multiple.ReadAsync<Medicion>();
                }
                else
                    return null;
            }

            if (usuario != null)
            {
                usuario.Vc50Contrasena = string.Empty;

                foreach (var zona in zonas)
                {
                    zona.Medicion = mediciones.FirstOrDefault(m => m.IdMedicion == zona.IdMedicion);
                }

                usuario.Zona = zonas.FirstOrDefault(z => z.IdZona == usuario.IdZona);

                return new
                {
                    usuario = usuario,
                    zonas = zonas
                };
            }

            return null;
        }

        public async Task UpdateEmailAsync(int idUser, string email)
        {
            var parameters = new
            {
                iduser = idUser,
                email = email
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_ActualizaCorreoUsuario]", parameters: parameters);
        }

        public async Task<dynamic> FindByZoneAsync(Object parameters)
        {
            IEnumerable<Usuario> userCollection = null;
            int totalCount = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_UsuarioListar]", parameters: parameters))
            {
                userCollection = await multiple.ReadAsync<Usuario>();
                totalCount = multiple.ReadSingle<int>();
            }
            
            return new
            { 
                records = userCollection,
                count = totalCount
            };
        }

        public async Task<Usuario> GetInfoAsync(int idUser)
        {
            var parameters = new
            {
                idUsuario = idUser
            };

            var result = await this.dbContext.QueryAsync<Usuario, Zona, Usuario>("[dbo].[Evo_UsuarioListarInformacionPersonal]",
                                                                   map: (usuario, zona) =>
                                                                   {
                                                                       usuario.Zona = zona;
                                                                       return usuario;
                                                                   },
                                                                   splitOn: "IdZona",
                                                                   parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<Perfil> GetProfileAsync(int idZone, int idUser)
        {
            var parameters = new
            {
                idUsuario = idUser,
                idzona = idZone
            };

            return await this.dbContext.QuerySingleAsync<Perfil>("[dbo].[UsuarioPerfil]", parameters: parameters);
        }

        public async Task<List<UsuarioZona>> GetUserZoneAsync(int user, int userUpdate)
        {
            var parameters = new
            {
                idusuario = user,
                idusuarioactualizador = userUpdate
            };

            var result = await this.dbContext.QueryAsync<UsuarioZona>("[dbo].[RelUsuarioZonaListar]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateUserZoneAsync(int iduser, int idzone, int acces)
        {
            var parameters = new
            {
                idusuario = iduser,
                idzona = idzone,
                acceso = (byte)acces
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioZonaActualizarAcceso]", parameters: parameters);
        }

        public async Task<List<UsuarioPerfil>> GetUserProfileAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<UsuarioPerfil>("[dbo].[PerfilListar]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateUserProfileAsync(UserProfileUpdateDto  model)
        {
            var parameters = new
            {
                idzona = model.Idzone,
                idusuario =  model.Iduser,
                idperfil =  model.IdProfile,
                acceso = model.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPerfilActualizarAcceso]", parameters: parameters);
        }

        public async Task<List<Pagina>> GetPagePermitAsync(int idzone, int iduser, int option)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario  = iduser,
                opcion  = option
            };

            var result = await this.dbContext.QueryAsync<Pagina>("[dbo].[Evo_RelPermisoZonaListar]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateUserPermitAsync(UserPermitUpdateDto model, UserchekUpdateDto detail)
        {
            var parameters = new
            {
                idzona = model.Idzone,
                idusuario = model.Iduser,
                idpagina = detail.Id,
                acceso = detail.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoActualizarAcceso]", parameters: parameters);
        }

        #region PlanDiarioPermisos
        public async Task<List<KeyValuePair<string,int>>> GetByPlanDailyAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<string, int>>("[dbo].[Evo_PlanDiarioInfo]", parameters: parameters);
            
            return result.ToList();
        }

        public async Task UpdatePlanDailyAsync(UserPlanDailyUpdateDto model)
        {
            var parameters = new
            {
                idusuario = model.IdUser,
                idzona  = model.IdZone,
                concretos = model.IdConcrete,
                clientes = model.IdClient,
                agregados = model.Aggregate,
                transporte =  model.Shipper,
                permisoconvenios  = model.AgreementPermit,
                permisoreglas = model.RulePermit
            };

            await this.dbContext.ExecuteAsync("[dbo].[UsuarioPermisoPlanDiarioActualizar]", parameters: parameters);
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyAgreggentAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_OrigenListarRelPlanDiarioPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateAgreggentAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                idorigen = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoPlanDiarioActualizarAccesoAgregados]", parameters: parameters);
        }

        public async Task UpdateAgreggentAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                actualiza = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_RelUsuarioPermisoPlanDiarioActualizarAccesoAgregadosTodos]", parameters: parameters);
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyConcretAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_DestinoListarRelPlanDiarioPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateConcretAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                iddestino = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoPlanDiarioActualizarAccesoConcretos]", parameters: parameters);
        }

        public async Task UpdateConcretAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                actualiza = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_RelUsuarioPermisoPlanDiarioActualizarAccesoConcretosTodos]", parameters: parameters);
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetPlanDailyShipperAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_TransportistaListarRelPlanDiarioPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateShipperAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                idtransportista = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoPlanDiarioActualizarAccesoTransporte]", parameters: parameters);
        }

        public async Task UpdateShipperAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                actualiza = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_RelUsuarioPermisoPlanDiarioActualizarAccesoTransporteTodos]", parameters: parameters);
        }
        #endregion

        #region Monitoreo

        public async Task<List<KeyValuePair<string, int>>> GetByMonitorAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<string, int>>("[dbo].[Evo_MonitoreoInfo]", parameters: parameters);

            return result.ToList();
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetMonitorAgreggentAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_OrigenListarRelMonitoreoPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateMonitorAgreggentAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                idorigen = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoActualizarAccesoAgregados]", parameters: parameters);
        }

        public async Task UpdateMonitorAgreggentAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                marcado = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_RelUsuarioPermisoActualizarAccesoAgregadosTodos]", parameters: parameters);
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetMonitorConcretAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_DestinoListarRelMonitoreoPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateMonitorConcretAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                iddestino = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoActualizarAccesoConcretos]", parameters: parameters);
        }

        public async Task UpdateMonitorConcretAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                marcado = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].Evo_RelUsuarioPermisoActualizarAccesoConcretosTodos", parameters: parameters);
        }

        public async Task<List<RelUsuarioPermisoAdmin>> GetMonitorShipperAsync(int idzone, int iduser)
        {
            var parameters = new
            {
                idzona = idzone,
                idusuario = iduser
            };

            var result = await this.dbContext.QueryAsync<RelUsuarioPermisoAdmin>("[dbo].[Evo_TransportistaListarRelMonitoreoPermiso]", parameters: parameters);

            return result.ToList();
        }

        public async Task UpdateMonitorShipperAsync(UserPermisionPlanDailyDto model, UserchekUpdateDto check)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                idtransportista = check.Id,
                acceso = check.Acess
            };

            await this.dbContext.ExecuteAsync("[dbo].[RelUsuarioPermisoActualizarAccesoTransporte]", parameters: parameters);
        }

        public async Task UpdateMonitorShipperAllAsync(UserPermisionPlanDailyAllDto model)
        {
            var parameters = new
            {
                idzona = model.idzona,
                idusuario = model.iduser,
                marcado = model.todos
            };

            await this.dbContext.ExecuteAsync("[dbo].[Evo_RelUsuarioPermisoActualizarAccesoTransporteTodos]", parameters: parameters);
        }

        public async Task UpdateMonitorAsync(UserSecurityManagementDto model)
        {
            var parameters = new
            {
                idusuario = model.IdUser,
                idzona = model.IdZone,
                permisoagregados = model.AgreementPermit,
                permisoconcretos = model.ConcretPermit,
                permisotransporte = model.ShipperPermit,
                permisoOL  = model.OLPermit
            };

            await this.dbContext.ExecuteAsync("[dbo].[MonitoreoActualizar]", parameters: parameters);
        }
        #endregion

        public async Task UserClonAsync(UserClonDto model)
        {
            await this.dbContext.ExecuteAsync("[dbo].[Evo_CloneUser]", parameters: model);
        }

        public async Task<IEnumerable<RelUsuarioPermiso>> PagePermissionsAsync(int idZone, int idUser, int page)
        {
            var parameters = new
            {
                idpagina = page,
                idusuario = idUser,
                idzona = idZone
            };

            return await this.dbContext.QueryAsync<RelUsuarioPermiso>("[dbo].[UsuarioListarPermisosPorPagina]", parameters: parameters);
        }

        public async Task<dynamic> MenuPermitAsync(int IdUser, int IdZone)
        {
            var parameters = new
            {
                idusuario = IdUser,
                idzona  = IdZone
            };

            IEnumerable<Modulo> moduleCollection = null;
            IEnumerable<SubModulo> submoduleCollection = null;
            IEnumerable<Pagina> pageCollection = null;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_UsuarioListarPermisos]", parameters: parameters))
            {
                moduleCollection = await multiple.ReadAsync<Modulo>();
                submoduleCollection = await multiple.ReadAsync<SubModulo>();
                pageCollection = await multiple.ReadAsync<Pagina>();
            }
            return new
            {
                module = moduleCollection,
                submodule = submoduleCollection,
                page = pageCollection
            };
        }

        public async Task<dynamic> GetUserForMailAsync(string email)
        {
            var parameters = new
            {
                email = email
            };

            Usuario usuario = null;
            IEnumerable<Zona> zonas = null;
            IEnumerable<Medicion> mediciones = null;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ConsultaUsuarioCorreo]", parameters: parameters))
            {
                var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var field = typeof(SqlMapper.GridReader).GetField("reader", bindFlags);
                var DataValues = (SqlDataReader)field?.GetValue(multiple);

                if (DataValues != null && DataValues.HasRows)
                {
                    usuario = await multiple.ReadSingleAsync<Usuario>();
                    zonas = await multiple.ReadAsync<Zona>();
                    mediciones = await multiple.ReadAsync<Medicion>();
                }
                else
                    return null;
            }

            
            usuario.Vc50Contrasena = string.Empty;

            foreach (var zona in zonas)
            {
                zona.Medicion = mediciones.FirstOrDefault(m => m.IdMedicion == zona.IdMedicion);
            }

            usuario.Zona = zonas.FirstOrDefault(z => z.IdZona == usuario.IdZona);

            return new
            {
                usuario = usuario,
                zonas = zonas
            };
        }
    }
}
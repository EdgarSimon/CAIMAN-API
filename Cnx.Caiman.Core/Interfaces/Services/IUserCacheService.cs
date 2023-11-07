using Cnx.Caiman.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IUserCacheService
    {
        UserDto Get(string email);

        void Remove(string email);

        void Set(string email, UserDto user);
    }
}

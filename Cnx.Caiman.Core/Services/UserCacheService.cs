using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class UserCacheService: IUserCacheService
    {
        private readonly Dictionary<string, UserDto > cache = new Dictionary<string, UserDto>();

        public UserDto Get(string email)
        {
            if (cache.ContainsKey(email))
            {
                return cache[email];
            }

            return null;
        }

        public void Remove(string email)
        {
            cache.Remove(email);
        }

        public void Set(string email, UserDto user)
        {
            if (cache.ContainsKey(email))
            {
                cache.Remove(email);
            }
            cache.Add(email, user);
        }

    }
}

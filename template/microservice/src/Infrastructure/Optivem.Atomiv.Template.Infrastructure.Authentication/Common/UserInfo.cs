﻿using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Common.Actions;
using Optivem.Atomiv.Template.Core.Common.Roles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.Common
{
    public class UserInfo
    {
        public UserInfo(Guid id, 
            string email, 
            string locale, 
            string mobile,
            IEnumerable<RoleType> roles,
            IEnumerable<ActionType> actions)
        {
            Id = id;
            Email = email;
            Locale = locale;
            Mobile = mobile;
            Roles = roles;
            Actions = actions;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Locale { get; }

        public string Mobile { get; }

        public IEnumerable<RoleType> Roles { get; }

        public IEnumerable<ActionType> Actions { get; }

        public IEnumerable<Claim> GetClaims()
        {
            var nameIdentifier = Id.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Locality, Locale),
                new Claim(ClaimTypes.MobilePhone, Mobile),
            };

            foreach(var role in Roles)
            {
                var roleValue = ((byte)role).ToString();
                claims.Add(new Claim(ClaimTypes.Role, roleValue));
            }

            foreach(var action in Actions)
            {
                var actionValue = ((byte)action).ToString();
                claims.Add(new Claim(ExtendedClaimTypes.ActionType, actionValue));
            }

            return claims;
        }
    }
}
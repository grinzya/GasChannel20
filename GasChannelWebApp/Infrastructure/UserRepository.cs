﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using GasChannelWebApp.Domain;
using System.Security.Policy;

namespace GasChannelWebApp.Infrastructure
{
    public class UserRepository : IUserProfileRepository
    {
        GasChannelDB _context;

        public UserRepository(GasChannelDB context)
        {
            _context = context;
        }

        IQueryable<UserProfile> IUserProfileRepository.All
        {
            get
            {
                return _context.UserProfiles;
            }
        }

        UserProfile IUserProfileRepository.CurrentUser
        {
            get
            {
                return _context
                    .UserProfiles
                    .Include("Variants")
                    .Include("InputDataVariants")
                    .Where(u => u.ID_User == WebSecurity.CurrentUserId)
                    .FirstOrDefault();
            }
        }

        void IUserProfileRepository.InsertOrUpdate(UserProfile user)
        {
            if (user.ID_User == default(int))
            {
                _context.UserProfiles.Add(user);
            }
            else
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
        }

        void IUserProfileRepository.Remove(UserProfile user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
        }

        void IUserProfileRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}
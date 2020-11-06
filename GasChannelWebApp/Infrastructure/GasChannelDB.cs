using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GasChannelWebApp.Domain;

namespace GasChannelWebApp.Infrastructure
{
    public class GasChannelDB : DbContext
    {
        public GasChannelDB() : base ("GasChannelConnection")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Variants> Variants { get; set; }

        public DbSet<InputDataVariants> InputDataVariants { get; set; }
    }
}
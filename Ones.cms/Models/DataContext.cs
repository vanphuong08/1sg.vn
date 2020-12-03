using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace Ones.cms.Models
{
    public class DataContext: DbContext
    {
        public DataContext() : base("name=connection")
        { }
        public DbSet<HOME> HOMEs { get; set; }
        public DbSet<MENU> MENUs { get; set; }
        public DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public DbSet<CONTACT> CONTACTs { get; set; }
        public DbSet<PARTNER> PARTNERs { get; set; }
        public DbSet<TEAM> TEAMs { get; set; }

    }
}
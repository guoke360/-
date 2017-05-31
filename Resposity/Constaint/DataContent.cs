using Resposity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Constaint
{
    public class DataContent : DbContext
    {
        public DataContent()
            : base("Shelf")
        {
        }
        public DbSet<BD_UserInfo> UserInfo { get; set; }
        public DbSet<Fc_Evaluate> Evaluate { get; set; }
        public DbSet<Fc_Install> Install { get; set; }
        public DbSet<Fc_Offer> Offer { get; set; }
        public DbSet<Fc_Step> Step { get; set; }
    }
}

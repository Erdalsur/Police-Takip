using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policem.Data.Common.Mapping;

namespace Policem.Data.Common.Concrete.EntityFramework
{
    public class PoliceContext:DbContext
    {
        public PoliceContext()
            :base("Name=PoliceTakip")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = false;
        }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Police> Policeler { get; set; }
        public DbSet<Sigortaci> Sigortacilar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new SigortaciMap());
            modelBuilder.Configurations.Add(new FirmaMap());
            modelBuilder.Configurations.Add(new PoliceMap());
        }
    }
    
}

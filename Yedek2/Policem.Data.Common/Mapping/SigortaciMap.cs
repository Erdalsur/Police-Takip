using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policem.Data.Common.Mapping
{
    public class SigortaciMap:EntityTypeConfiguration<Sigortaci>
    {
        public SigortaciMap()
        {
            Property(one => one.SigortaciAdi).HasMaxLength(30).IsRequired();
            ToTable("Sigortacilar");
        }
    }

}

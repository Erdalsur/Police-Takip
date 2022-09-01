using System.Data.Entity.ModelConfiguration;

namespace Policem.Data.Common.Mapping
{
    public class PoliceDosyaMap : EntityTypeConfiguration<PoliceDosyaDetay>
    {
        public PoliceDosyaMap()
        {
            //HasRequired(one => one.Sigortaci).WithMany(one => one.Policeler).HasForeignKey(one => one.SigortaciId);
            //HasRequired(one => one.Firma).WithMany(one => one.Policeler).HasForeignKey(one => one.FirmaId);
            ToTable("PoliceDosyalar");
        }
    }

}

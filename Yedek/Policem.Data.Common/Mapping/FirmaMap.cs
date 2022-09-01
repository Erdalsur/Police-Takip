using System.Data.Entity.ModelConfiguration;

namespace Policem.Data.Common.Mapping
{
    public class FirmaMap : EntityTypeConfiguration<Firma>
    {
        public FirmaMap()
        {
            HasKey(t => t.FirmaId);
            Property(one => one.Kod).HasMaxLength(10).IsRequired();
            Property(one => one.Name).HasMaxLength(30).IsRequired();
            Property(one => one.Unvan).HasMaxLength(30).IsRequired();
            Property(one => one.VKNO).HasMaxLength(11).IsRequired();
            Property(one => one.Yetkili).HasMaxLength(20).IsRequired();
            
            ToTable("Firmalar");
        }
    }

}

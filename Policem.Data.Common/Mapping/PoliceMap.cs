using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Policem.Data.Common.Mapping
{
    public class PoliceMap:EntityTypeConfiguration<Police>
    {
        public PoliceMap()
        {
            //HasRequired(one => one.Sigortaci).WithMany(one => one.Policeler).HasForeignKey(one => one.SigortaciId);
            //HasRequired(one => one.Firma).WithMany(one => one.Policeler).HasForeignKey(one => one.FirmaId);
            ToTable("Policeler");
        }
    }
    public class GelmeyenPoliceMap : EntityTypeConfiguration<GelmeyenPolice>
    {
        public GelmeyenPoliceMap()
        {
            // Primary Key
            this.HasKey(t => new
            {
                t.PoliceId,
                t.Name,
                t.PoliceTuru,
                t.PoliceBaslangicTarih,
                t.PoliceBitisTarih,
                t.Tutar,
                t.ArtisYuzdesi
            });

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.PoliceTuru)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tutar)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ArtisYuzdesi)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("GelmeyenPoliceler");
            this.Property(t => t.PoliceId).HasColumnName("PoliceId");
            this.Property(t => t.Unvan).HasColumnName("Unvan");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PoliceTuru).HasColumnName("PoliceTuru");
            this.Property(t => t.PoliceNo).HasColumnName("PoliceNo");
            this.Property(t => t.PoliceBaslangicTarih).HasColumnName("PoliceBaslangicTarih");
            this.Property(t => t.PoliceBitisTarih).HasColumnName("PoliceBitisTarih");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.Policelenen).HasColumnName("Policelenen");
            this.Property(t => t.Tutar).HasColumnName("Tutar");
            this.Property(t => t.ArtisYuzdesi).HasColumnName("ArtisYuzdesi");
        }
    }
}

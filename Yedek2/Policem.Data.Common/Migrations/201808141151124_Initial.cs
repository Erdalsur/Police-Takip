namespace Policem.Data.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firmalar",
                c => new
                {
                    FirmaId = c.Int(nullable: false, identity: true),
                    Kod = c.String(nullable: false, maxLength: 10),
                    Name = c.String(nullable: false, maxLength: 30),
                    Unvan = c.String(nullable: false, maxLength: 30),
                    Yetkili = c.String(nullable: false, maxLength: 20),
                    VKNO = c.String(nullable: false, maxLength: 11),
                })
                .PrimaryKey(t => t.FirmaId);

            CreateTable(
                "dbo.Policeler",
                c => new
                {
                    PoliceId = c.Int(nullable: false, identity: true),
                    FirmaId = c.Int(nullable: false),
                    SigortaciId = c.Int(nullable: false),
                    Aciklama = c.String(),
                    PoliceTuru = c.Int(nullable: false),
                    PoliceNo = c.String(),
                    PoliceBaslangicTarih = c.DateTime(nullable: false),
                    PoliceBitisTarih = c.DateTime(nullable: false),
                    Policelenen = c.String(),
                    OdemeTuru = c.Int(nullable: false),
                    Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    OncekiTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ArtisYuzdesi = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Taksit = c.Int(nullable: false),
                    TaksitSayisi = c.Int(nullable: false),
                    Yenilendimi = c.Int(nullable: false),
                    YeniPoliceId = c.Int(nullable: false),
                    PoliceGeldimi = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PoliceId)
                .ForeignKey("dbo.Firmalar", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Sigortacilar", t => t.SigortaciId, cascadeDelete: true)
                .Index(t => t.FirmaId)
                .Index(t => t.SigortaciId);

            CreateTable(
                "dbo.Sigortacilar",
                c => new
                {
                    SigortaciId = c.Int(nullable: false, identity: true),
                    FirmaNo = c.String(),
                    SigortaciAdi = c.String(nullable: false, maxLength: 30),
                    Unvan = c.String(),
                    HasarNumarasi = c.String(),
                    TemsilciAdi = c.String(),
                    TemsilciTel = c.String(),
                })
                .PrimaryKey(t => t.SigortaciId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Policeler", "SigortaciId", "dbo.Sigortacilar");
            DropForeignKey("dbo.Policeler", "FirmaId", "dbo.Firmalar");
            DropIndex("dbo.Policeler", new[] { "SigortaciId" });
            DropIndex("dbo.Policeler", new[] { "FirmaId" });
            DropTable("dbo.Sigortacilar");
            DropTable("dbo.Policeler");
            DropTable("dbo.Firmalar");
        }
    }
}

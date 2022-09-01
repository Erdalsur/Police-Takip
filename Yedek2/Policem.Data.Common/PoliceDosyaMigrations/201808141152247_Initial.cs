namespace Policem.Data.Common.PoliceDosyaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoliceDosyalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoliceId = c.Int(nullable: false),
                        Dosya = c.Binary(),
                        DosyaType = c.String(),
                        Aciklama = c.String(),
                        Dosyalandimi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PoliceDosyalar");
        }
    }
}

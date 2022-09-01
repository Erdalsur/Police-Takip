namespace Policem.Data.Common.PoliceDosyaMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Policem.Data.Common.Concrete.EntityFramework.PoliceDosyaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"PoliceDosyaMigrations";
        }

        protected override void Seed(Policem.Data.Common.Concrete.EntityFramework.PoliceDosyaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

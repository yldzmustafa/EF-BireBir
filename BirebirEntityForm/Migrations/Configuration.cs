namespace BirebirEntityForm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BirebirEntityForm.Baglanti>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BirebirEntityForm.Baglanti";
        }

        protected override void Seed(BirebirEntityForm.Baglanti context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

namespace TiendaVirtual_ETS.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TiendaVirtual_ETS.Data.TiendaVirtual_ETSContext>
    {
        public Configuration()
        {


            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TiendaVirtual_ETS.Data.TiendaVirtual_ETSContext";
        }

    

        protected override void Seed(TiendaVirtual_ETS.Data.TiendaVirtual_ETSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

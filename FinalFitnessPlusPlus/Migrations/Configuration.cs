namespace FinalFitnessPlusPlus.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalFitnessPlusPlus.Data.FinalFitnessPlusPlusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FinalFitnessPlusPlus.Data.FinalFitnessPlusPlusContext";
        }

        protected override void Seed(FinalFitnessPlusPlus.Data.FinalFitnessPlusPlusContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

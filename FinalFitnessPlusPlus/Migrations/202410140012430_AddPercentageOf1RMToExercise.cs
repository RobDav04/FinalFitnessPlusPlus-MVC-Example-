using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Data.Entity;

namespace FinalFitnessPlusPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPercentageOf1RMToExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "PercentageOf1RM", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "PercentageOf1RM");
        }
    }
}

using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Data.Entity;

namespace FinalFitnessPlusPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalSetsToExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "TotalSets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "TotalSets");
        }
    }
}

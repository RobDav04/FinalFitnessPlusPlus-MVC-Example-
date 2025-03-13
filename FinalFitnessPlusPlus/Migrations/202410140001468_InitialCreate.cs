namespace FinalFitnessPlusPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Repetitions = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        MuscleGroupID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MuscleGroups", t => t.MuscleGroupID)
                .Index(t => t.MuscleGroupID);
            
            CreateTable(
                "dbo.MuscleGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "MuscleGroupID", "dbo.MuscleGroups");
            DropIndex("dbo.Exercises", new[] { "MuscleGroupID" });
            DropTable("dbo.MuscleGroups");
            DropTable("dbo.Exercises");
        }
    }
}

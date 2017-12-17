namespace CarsNOwners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTypeOfPrice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarOwners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerId, t.CarId })
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Brand = c.String(),
                        TypeOfAuto = c.String(),
                        Price = c.Single(nullable: false),
                        YearOfIssue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        YearOfBirth = c.Int(nullable: false),
                        ExpirienceOfDriving = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarOwners", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.CarOwners", "CarId", "dbo.Cars");
            DropIndex("dbo.CarOwners", new[] { "CarId" });
            DropIndex("dbo.CarOwners", new[] { "OwnerId" });
            DropTable("dbo.Owners");
            DropTable("dbo.Cars");
            DropTable("dbo.CarOwners");
        }
    }
}

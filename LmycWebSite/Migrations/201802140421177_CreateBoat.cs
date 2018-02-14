namespace LmycWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBoat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        BoatId = c.Int(nullable: false, identity: true),
                        BoatName = c.String(),
                        Picture = c.Binary(),
                        LengthInFeet = c.Int(nullable: false),
                        Make = c.String(),
                        Year = c.Int(nullable: false),
                        RecordCreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BoatId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boats", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Boats", new[] { "CreatedBy" });
            DropTable("dbo.Boats");
        }
    }
}

namespace LmycWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBoat1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Boats", name: "CreatedBy", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Boats", name: "IX_CreatedBy", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {   
            RenameIndex(table: "dbo.Boats", name: "IX_ApplicationUser_Id", newName: "IX_CreatedBy");
            RenameColumn(table: "dbo.Boats", name: "ApplicationUser_Id", newName: "CreatedBy");
        }
    }
}

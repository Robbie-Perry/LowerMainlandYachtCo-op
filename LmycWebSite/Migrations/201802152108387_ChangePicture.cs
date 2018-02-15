namespace LmycWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePicture : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boats", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boats", "Picture", c => c.Binary());
        }
    }
}

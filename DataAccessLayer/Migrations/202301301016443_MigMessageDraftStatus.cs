namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigMessageDraftStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DraftStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DraftStatus");
        }
    }
}

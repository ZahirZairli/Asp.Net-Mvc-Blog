namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigMessageReadingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReadingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReadingStatus");
        }
    }
}

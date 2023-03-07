namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryStatusDefaultvalue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }
    }
}

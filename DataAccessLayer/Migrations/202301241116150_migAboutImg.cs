namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migAboutImg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "AboutImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage", c => c.String());
        }
    }
}

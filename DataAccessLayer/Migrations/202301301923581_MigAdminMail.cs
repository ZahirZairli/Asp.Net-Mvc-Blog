namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigAdminMail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminMail");
        }
    }
}

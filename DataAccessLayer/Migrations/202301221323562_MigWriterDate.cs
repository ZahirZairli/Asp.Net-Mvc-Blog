namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigWriterDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterDate");
        }
    }
}

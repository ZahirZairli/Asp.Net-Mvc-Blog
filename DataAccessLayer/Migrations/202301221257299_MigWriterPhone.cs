namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigWriterPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterPhone");
        }
    }
}

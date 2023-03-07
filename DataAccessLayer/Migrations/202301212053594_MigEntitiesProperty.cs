namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigEntitiesProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutDetails1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutDetails2", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.Headings", "HeadingName", c => c.String());
            AlterColumn("dbo.Contents", "ContentValue", c => c.String());
            AlterColumn("dbo.Writers", "WriterName", c => c.String());
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String());
            AlterColumn("dbo.Writers", "WriterImage", c => c.String());
            AlterColumn("dbo.Writers", "WriterMail", c => c.String());
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String());
            AlterColumn("dbo.Contacts", "UserName", c => c.String());
            AlterColumn("dbo.Contacts", "UserMail", c => c.String());
            AlterColumn("dbo.Contacts", "UserSubject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "UserSubject", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutDetails2", c => c.String(maxLength: 500));
            AlterColumn("dbo.Abouts", "AboutDetails1", c => c.String(nullable: false, maxLength: 500));
        }
    }
}

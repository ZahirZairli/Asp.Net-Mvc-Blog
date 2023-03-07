namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigMeSkil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Me", "MySkill11", c => c.String());
            AddColumn("dbo.Me", "MySkillPercentage11", c => c.String());
            AddColumn("dbo.Me", "MySkill12", c => c.String());
            AddColumn("dbo.Me", "MySkillPercentage12", c => c.String());
            AddColumn("dbo.Me", "MySkill13", c => c.String());
            AddColumn("dbo.Me", "MySkillPercentage13", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Me", "MySkillPercentage13");
            DropColumn("dbo.Me", "MySkill13");
            DropColumn("dbo.Me", "MySkillPercentage12");
            DropColumn("dbo.Me", "MySkill12");
            DropColumn("dbo.Me", "MySkillPercentage11");
            DropColumn("dbo.Me", "MySkill11");
        }
    }
}

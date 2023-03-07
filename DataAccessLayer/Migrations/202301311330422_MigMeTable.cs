namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigMeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Me",
                c => new
                    {
                        MeId = c.Int(nullable: false, identity: true),
                        MeName = c.String(),
                        MeSurname = c.String(),
                        MePhoto = c.String(),
                        MySkill1 = c.String(),
                        MySkillPercentage1 = c.String(),
                        MySkill2 = c.String(),
                        MySkillPercentage2 = c.String(),
                        MySkill3 = c.String(),
                        MySkillPercentage3 = c.String(),
                        MySkill4 = c.String(),
                        MySkillPercentage4 = c.String(),
                        MySkill5 = c.String(),
                        MySkillPercentage5 = c.String(),
                        MySkill6 = c.String(),
                        MySkillPercentage6 = c.String(),
                        MySkill7 = c.String(),
                        MySkillPercentage7 = c.String(),
                        MySkill8 = c.String(),
                        MySkillPercentage8 = c.String(),
                        MySkill9 = c.String(),
                        MySkillPercentage9 = c.String(),
                        MySkill10 = c.String(),
                        MySkillPercentage10 = c.String(),
                    })
                .PrimaryKey(t => t.MeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Me");
        }
    }
}

namespace MiniprojektRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cId = c.Int(nullable: false),
                        QuestionText = c.String(nullable: false),
                        AnswerText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategories", t => t.cId, cascadeDelete: true)
                .Index(t => t.cId);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "cId", "dbo.QuestionCategories");
            DropIndex("dbo.Questions", new[] { "cId" });
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Questions");
        }
    }
}

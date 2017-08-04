namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
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
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Required = c.Boolean(nullable: false),
                        Content = c.String(),
                        SurveyPage_Id = c.Int(),
                        Lookup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPages", t => t.SurveyPage_Id)
                .ForeignKey("dbo.SurveyLookups", t => t.Lookup_Id)
                .Index(t => t.SurveyPage_Id)
                .Index(t => t.Lookup_Id);
            
            CreateTable(
                "dbo.SurveyLookups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Survey_Id = c.Int(),
                        Template_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .ForeignKey("dbo.Templates", t => t.Template_Id)
                .Index(t => t.Survey_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyLookup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyLookups", t => t.SurveyLookup_Id)
                .Index(t => t.SurveyLookup_Id);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Lookup_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReplyLookups", t => t.Lookup_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Lookup_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.ReplyLookups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalUserId = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Replies", "Lookup_Id", "dbo.ReplyLookups");
            DropForeignKey("dbo.ReplyLookups", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Questions", "Lookup_Id", "dbo.SurveyLookups");
            DropForeignKey("dbo.SurveyLookups", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.SurveyPages", "SurveyLookup_Id", "dbo.SurveyLookups");
            DropForeignKey("dbo.Questions", "SurveyPage_Id", "dbo.SurveyPages");
            DropForeignKey("dbo.SurveyLookups", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.ReplyLookups", new[] { "User_Id" });
            DropIndex("dbo.Replies", new[] { "Question_Id" });
            DropIndex("dbo.Replies", new[] { "Lookup_Id" });
            DropIndex("dbo.SurveyPages", new[] { "SurveyLookup_Id" });
            DropIndex("dbo.SurveyLookups", new[] { "Template_Id" });
            DropIndex("dbo.SurveyLookups", new[] { "Survey_Id" });
            DropIndex("dbo.Questions", new[] { "Lookup_Id" });
            DropIndex("dbo.Questions", new[] { "SurveyPage_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.ReplyLookups");
            DropTable("dbo.Replies");
            DropTable("dbo.Templates");
            DropTable("dbo.SurveyPages");
            DropTable("dbo.Surveys");
            DropTable("dbo.SurveyLookups");
            DropTable("dbo.Questions");
        }
    }
}

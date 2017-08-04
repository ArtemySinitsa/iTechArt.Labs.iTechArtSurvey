namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Required = c.Boolean(nullable: false),
                        XmlContent = c.String(storeType: "xml"),
                        SurveyPage_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPages", t => t.SurveyPage_Id, cascadeDelete: true)
                .Index(t => t.SurveyPage_Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                        UserReply_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserReplies", t => t.Id)
                .ForeignKey("dbo.UserReplies", t => t.UserReply_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UserReply_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.UserReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReplyDateTime = c.DateTime(nullable: false),
                        Survey_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Survey_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        LastModified = c.DateTime(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
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
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.TemplateLookups",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPages", t => t.Id)
                .ForeignKey("dbo.Templates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SurveyPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyLookups",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPages", t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SurveyPage_Id", "dbo.SurveyPages");
            DropForeignKey("dbo.Replies", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Replies", "UserReply_Id", "dbo.UserReplies");
            DropForeignKey("dbo.UserReplies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserReplies", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.SurveyLookups", "Id", "dbo.Surveys");
            DropForeignKey("dbo.SurveyLookups", "Id", "dbo.SurveyPages");
            DropForeignKey("dbo.Templates", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.TemplateLookups", "Id", "dbo.Templates");
            DropForeignKey("dbo.TemplateLookups", "Id", "dbo.SurveyPages");
            DropForeignKey("dbo.Surveys", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Replies", "Id", "dbo.UserReplies");
            DropIndex("dbo.SurveyLookups", new[] { "Id" });
            DropIndex("dbo.TemplateLookups", new[] { "Id" });
            DropIndex("dbo.Templates", new[] { "Author_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Surveys", new[] { "Author_Id" });
            DropIndex("dbo.UserReplies", new[] { "User_Id" });
            DropIndex("dbo.UserReplies", new[] { "Survey_Id" });
            DropIndex("dbo.Replies", new[] { "Question_Id" });
            DropIndex("dbo.Replies", new[] { "UserReply_Id" });
            DropIndex("dbo.Replies", new[] { "Id" });
            DropIndex("dbo.Questions", new[] { "SurveyPage_Id" });
            DropTable("dbo.SurveyLookups");
            DropTable("dbo.SurveyPages");
            DropTable("dbo.TemplateLookups");
            DropTable("dbo.Templates");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Surveys");
            DropTable("dbo.UserReplies");
            DropTable("dbo.Replies");
            DropTable("dbo.Questions");
        }
    }
}

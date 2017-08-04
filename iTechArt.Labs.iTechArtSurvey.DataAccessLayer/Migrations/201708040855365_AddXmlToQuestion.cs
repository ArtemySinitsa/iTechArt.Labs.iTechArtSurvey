namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddXmlToQuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users");
            DropIndex("dbo.SurveyLookups", new[] { "Author_Id" });
            AddColumn("dbo.Questions", "XmlContent", c => c.String(storeType: "xml"));
            AlterColumn("dbo.SurveyLookups", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.SurveyLookups", "Author_Id");
            AddForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Content", c => c.String());
            DropForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users");
            DropIndex("dbo.SurveyLookups", new[] { "Author_Id" });
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.SurveyLookups", "Author_Id", c => c.Int());
            DropColumn("dbo.Questions", "XmlContent");
            CreateIndex("dbo.SurveyLookups", "Author_Id");
            AddForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users", "Id");
        }
    }
}

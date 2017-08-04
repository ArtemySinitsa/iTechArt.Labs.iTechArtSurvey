namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupUsersCollections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyLookups", "Author_Id", c => c.Int());
            CreateIndex("dbo.SurveyLookups", "Author_Id");
            AddForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users", "Id");
            DropColumn("dbo.Surveys", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "AuthorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SurveyLookups", "Author_Id", "dbo.Users");
            DropIndex("dbo.SurveyLookups", new[] { "Author_Id" });
            DropColumn("dbo.SurveyLookups", "Author_Id");
        }
    }
}

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuestionToReferenceOnSurveyPage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Lookup_Id", "dbo.SurveyLookups");
            DropIndex("dbo.Questions", new[] { "Lookup_Id" });
            DropColumn("dbo.Questions", "Lookup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Lookup_Id", c => c.Int());
            CreateIndex("dbo.Questions", "Lookup_Id");
            AddForeignKey("dbo.Questions", "Lookup_Id", "dbo.SurveyLookups", "Id");
        }
    }
}

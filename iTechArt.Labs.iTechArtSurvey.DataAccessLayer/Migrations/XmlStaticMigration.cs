namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class xml : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "XmlContent");
            string schema = "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" " +
             "           elementFormDefault=\"qualified\" " +
             "           attributeFormDefault=\"unqualified\">" +
             "  <xs:element name=\"question\">" +
             "    <xs:complexType>" +
             "      <xs:choice>" +
             "        <xs:sequence>" +
             "          <xs:element name=\"choice\" maxOccurs=\"unbounded\" minOccurs=\"1\" type=\"xs:string\"></xs:element>" +
             "        </xs:sequence>" +
             "        <xs:element name=\"description\"></xs:element>" +
             "        <xs:element name=\"rate\">" +
             "          <xs:complexType>" +
             "            <xs:attribute name=\"value\" type=\"xs:short\" use=\"required\" />" +
             "          </xs:complexType>" +
             "        </xs:element>" +
             "        <xs:element name=\"range\">" +
             "          <xs:complexType>" +
             "            <xs:attribute name=\"minimum\" type=\"xs:short\" use=\"required\" />" +
             "            <xs:attribute name=\"maximum\" type=\"xs:short\" use=\"required\" />" +
             "            <xs:attribute name=\"step\" type=\"xs:short\" use=\"required\" />" +
             "          </xs:complexType>" +
             "        </xs:element>" +
             "      </xs:choice>" +
             "    </xs:complexType>" +
             "  </xs:element>" +
             "</xs:schema>";

            Sql("CREATE XML SCHEMA COLLECTION QuestionTypes AS N'" + schema + "';");
            Sql("ALTER TABLE dbo.Questions ADD XmlContent Xml(QuestionTypes)");
        }

        public override void Down()
        {
            Sql("DROP XML SCHEMA COLLECTION QuestionTypes");
            DropColumn("dbo.Questions", "XmlContent");
            AddColumn("dbo.Questions", "XmlContent", c => c.String(storeType: "xml"));
        }
    }
}

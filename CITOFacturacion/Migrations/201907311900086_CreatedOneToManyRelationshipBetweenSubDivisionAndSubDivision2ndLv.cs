namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOneToManyRelationshipBetweenSubDivisionAndSubDivision2ndLv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDivision2ndLv", "SubDivisionId", c => c.Guid());
            CreateIndex("dbo.SubDivision2ndLv", "SubDivisionId");
            AddForeignKey("dbo.SubDivision2ndLv", "SubDivisionId", "dbo.SubDivisions", "SubDivisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDivision2ndLv", "SubDivisionId", "dbo.SubDivisions");
            DropIndex("dbo.SubDivision2ndLv", new[] { "SubDivisionId" });
            DropColumn("dbo.SubDivision2ndLv", "SubDivisionId");
        }
    }
}

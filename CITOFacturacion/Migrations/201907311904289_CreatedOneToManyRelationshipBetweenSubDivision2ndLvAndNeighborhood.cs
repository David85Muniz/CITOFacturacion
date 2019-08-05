namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOneToManyRelationshipBetweenSubDivision2ndLvAndNeighborhood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Neighborhoods", "SubDivision2ndLvId", c => c.Guid());
            CreateIndex("dbo.Neighborhoods", "SubDivision2ndLvId");
            AddForeignKey("dbo.Neighborhoods", "SubDivision2ndLvId", "dbo.SubDivision2ndLv", "SubDivision2ndLvId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Neighborhoods", "SubDivision2ndLvId", "dbo.SubDivision2ndLv");
            DropIndex("dbo.Neighborhoods", new[] { "SubDivision2ndLvId" });
            DropColumn("dbo.Neighborhoods", "SubDivision2ndLvId");
        }
    }
}

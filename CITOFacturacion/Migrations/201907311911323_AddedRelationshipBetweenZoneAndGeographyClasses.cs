namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipBetweenZoneAndGeographyClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDivisions", "Zone_ZoneId", c => c.Guid());
            AddColumn("dbo.SubDivision2ndLv", "Zone_ZoneId", c => c.Guid());
            AddColumn("dbo.Neighborhoods", "Zone_ZoneId", c => c.Guid());
            AddColumn("dbo.Zones", "Neighborhood_NeighborhoodId", c => c.Guid());
            CreateIndex("dbo.SubDivisions", "Zone_ZoneId");
            CreateIndex("dbo.SubDivision2ndLv", "Zone_ZoneId");
            CreateIndex("dbo.Neighborhoods", "Zone_ZoneId");
            CreateIndex("dbo.Zones", "Neighborhood_NeighborhoodId");
            AddForeignKey("dbo.Zones", "Neighborhood_NeighborhoodId", "dbo.Neighborhoods", "NeighborhoodId");
            AddForeignKey("dbo.Neighborhoods", "Zone_ZoneId", "dbo.Zones", "ZoneId");
            AddForeignKey("dbo.SubDivisions", "Zone_ZoneId", "dbo.Zones", "ZoneId");
            AddForeignKey("dbo.SubDivision2ndLv", "Zone_ZoneId", "dbo.Zones", "ZoneId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDivision2ndLv", "Zone_ZoneId", "dbo.Zones");
            DropForeignKey("dbo.SubDivisions", "Zone_ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Neighborhoods", "Zone_ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "Neighborhood_NeighborhoodId", "dbo.Neighborhoods");
            DropIndex("dbo.Zones", new[] { "Neighborhood_NeighborhoodId" });
            DropIndex("dbo.Neighborhoods", new[] { "Zone_ZoneId" });
            DropIndex("dbo.SubDivision2ndLv", new[] { "Zone_ZoneId" });
            DropIndex("dbo.SubDivisions", new[] { "Zone_ZoneId" });
            DropColumn("dbo.Zones", "Neighborhood_NeighborhoodId");
            DropColumn("dbo.Neighborhoods", "Zone_ZoneId");
            DropColumn("dbo.SubDivision2ndLv", "Zone_ZoneId");
            DropColumn("dbo.SubDivisions", "Zone_ZoneId");
        }
    }
}

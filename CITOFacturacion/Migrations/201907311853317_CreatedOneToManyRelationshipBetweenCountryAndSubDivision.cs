namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOneToManyRelationshipBetweenCountryAndSubDivision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubDivisions", "CountryId", c => c.Guid());
            CreateIndex("dbo.SubDivisions", "CountryId");
            AddForeignKey("dbo.SubDivisions", "CountryId", "dbo.Countries", "CountryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubDivisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.SubDivisions", new[] { "CountryId" });
            DropColumn("dbo.SubDivisions", "CountryId");
        }
    }
}

namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGeographyClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        BillingAddressId = c.Guid(nullable: false, identity: true),
                        PostalCode = c.String(),
                        Street = c.String(),
                        OutsideNumber = c.String(),
                        InsideNumber = c.String(),
                        Neighborhood_NeighborhoodId = c.Guid(),
                    })
                .PrimaryKey(t => t.BillingAddressId)
                .ForeignKey("dbo.Neighborhoods", t => t.Neighborhood_NeighborhoodId)
                .Index(t => t.Neighborhood_NeighborhoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingAddresses", "Neighborhood_NeighborhoodId", "dbo.Neighborhoods");
            DropIndex("dbo.BillingAddresses", new[] { "Neighborhood_NeighborhoodId" });
            DropTable("dbo.BillingAddresses");
        }
    }
}

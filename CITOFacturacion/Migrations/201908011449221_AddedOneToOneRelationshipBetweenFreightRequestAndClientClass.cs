namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToOneRelationshipBetweenFreightRequestAndClientClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FreightRequests", "ClientId", c => c.Guid());
            CreateIndex("dbo.FreightRequests", "ClientId");
            AddForeignKey("dbo.FreightRequests", "ClientId", "dbo.Clients", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FreightRequests", "ClientId", "dbo.Clients");
            DropIndex("dbo.FreightRequests", new[] { "ClientId" });
            DropColumn("dbo.FreightRequests", "ClientId");
        }
    }
}

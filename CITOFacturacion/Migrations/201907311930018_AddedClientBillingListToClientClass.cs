namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientBillingListToClientClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingAddresses", "Client_ClientID", c => c.Guid());
            CreateIndex("dbo.BillingAddresses", "Client_ClientID");
            AddForeignKey("dbo.BillingAddresses", "Client_ClientID", "dbo.Clients", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingAddresses", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.BillingAddresses", new[] { "Client_ClientID" });
            DropColumn("dbo.BillingAddresses", "Client_ClientID");
        }
    }
}

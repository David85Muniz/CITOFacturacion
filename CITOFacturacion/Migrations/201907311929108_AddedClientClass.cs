namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        ClientContactName = c.String(),
                        ClientContactEMail = c.String(),
                        Notes = c.String(),
                        RFC = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}

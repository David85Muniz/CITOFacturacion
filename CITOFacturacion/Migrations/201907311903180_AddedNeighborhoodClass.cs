namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNeighborhoodClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        NeighborhoodId = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.NeighborhoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Neighborhoods");
        }
    }
}

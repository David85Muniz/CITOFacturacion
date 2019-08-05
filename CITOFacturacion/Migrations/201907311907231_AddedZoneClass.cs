namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZoneClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneId = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ZoneId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zones");
        }
    }
}

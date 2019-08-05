namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFreightRequestClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FreightRequests",
                c => new
                    {
                        FreightRequestId = c.Int(nullable: false, identity: true),
                        Restrictions = c.String(),
                        ReqClientRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FreightRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FreightRequests");
        }
    }
}

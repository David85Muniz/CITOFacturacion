namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubDivision2ndLvClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubDivision2ndLv",
                c => new
                    {
                        SubDivision2ndLvId = c.Guid(nullable: false, identity: true),
                        ShortName = c.String(),
                        LongName = c.String(),
                        Abbreviation = c.String(),
                        OriginCityId = c.Guid(),
                        DestinationCityId = c.Guid(),
                    })
                .PrimaryKey(t => t.SubDivision2ndLvId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubDivision2ndLv");
        }
    }
}

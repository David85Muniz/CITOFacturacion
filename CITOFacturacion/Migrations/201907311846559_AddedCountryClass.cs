namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Guid(nullable: false, identity: true),
                        ShortName = c.String(),
                        LongName = c.String(),
                        Code2Char = c.String(),
                        Code3Char = c.String(),
                        CodeNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
        }
    }
}

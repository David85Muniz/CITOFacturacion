namespace CITOFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubDivisionClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubDivisions",
                c => new
                    {
                        SubDivisionId = c.Guid(nullable: false, identity: true),
                        ShortName = c.String(),
                        LongName = c.String(),
                        AKA = c.String(),
                        Abbreviation = c.String(),
                        Code2Char = c.String(),
                        Code3Char = c.String(),
                    })
                .PrimaryKey(t => t.SubDivisionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubDivisions");
        }
    }
}

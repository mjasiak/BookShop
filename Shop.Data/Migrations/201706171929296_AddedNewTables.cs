namespace Shop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        CarrierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CarrierId);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        CoverId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CoverId);
            
            CreateTable(
                "dbo.Editions",
                c => new
                    {
                        EditionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EditionId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publishers");
            DropTable("dbo.Editions");
            DropTable("dbo.Covers");
            DropTable("dbo.Carriers");
        }
    }
}

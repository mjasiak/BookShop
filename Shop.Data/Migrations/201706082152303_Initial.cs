namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReleaseDate = c.DateTime(nullable: false),
                        SuperBargain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}

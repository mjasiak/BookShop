namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(maxLength: 75));
            AlterColumn("dbo.Books", "Author", c => c.String(maxLength: 75));
            AlterColumn("dbo.Books", "Publisher", c => c.String(maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Publisher", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
        }
    }
}

namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeCorrection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Type", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Type");
        }
    }
}

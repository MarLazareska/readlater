namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserId_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "UserId");
        }
    }
}

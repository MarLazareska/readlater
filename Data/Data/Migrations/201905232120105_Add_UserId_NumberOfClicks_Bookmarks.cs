namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserId_NumberOfClicks_Bookmarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "NumberOfClicks", c => c.Int(nullable: false));
            AddColumn("dbo.Bookmarks", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "UserId");
            DropColumn("dbo.Bookmarks", "NumberOfClicks");
        }
    }
}

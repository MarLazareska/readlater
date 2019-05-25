namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_NN_Bookmark_Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NN_Bookmark_Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookmarkId = c.Int(nullable: false),
                        NumberOfClicks = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId, cascadeDelete: true)
                .Index(t => t.BookmarkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NN_Bookmark_Account", "BookmarkId", "dbo.Bookmarks");
            DropIndex("dbo.NN_Bookmark_Account", new[] { "BookmarkId" });
            DropTable("dbo.NN_Bookmark_Account");
        }
    }
}

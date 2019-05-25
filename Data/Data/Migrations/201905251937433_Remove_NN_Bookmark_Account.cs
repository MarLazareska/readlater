namespace ReadLater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_NN_Bookmark_Account : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NN_Bookmark_Account", "BookmarkId", "dbo.Bookmarks");
            DropIndex("dbo.NN_Bookmark_Account", new[] { "BookmarkId" });
            DropTable("dbo.NN_Bookmark_Account");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.NN_Bookmark_Account", "BookmarkId");
            AddForeignKey("dbo.NN_Bookmark_Account", "BookmarkId", "dbo.Bookmarks", "ID", cascadeDelete: true);
        }
    }
}

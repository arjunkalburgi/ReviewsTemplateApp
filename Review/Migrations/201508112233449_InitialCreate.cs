namespace Review.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Itemreview",
                c => new
                    {
                        ItemreviewID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        WrittenReview = c.String(),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.ItemreviewID)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Itemreview", "ItemID", "dbo.Item");
            DropIndex("dbo.Itemreview", new[] { "ItemID" });
            DropTable("dbo.Item");
            DropTable("dbo.Itemreview");
        }
    }
}

namespace Review.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemName", c => c.String(maxLength: 50));
        }
    }
}

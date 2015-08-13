namespace Review.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnItemName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Item", name: "Title", newName: "ItemName");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Item", name: "ItemName", newName: "Title");
        }
    }
}

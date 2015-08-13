namespace Review.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Title", c => c.String());
        }
    }
}

namespace ECom.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScreperUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScreperURLs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SUrl = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScreperURLs", "ProductID", "dbo.Products");
            DropIndex("dbo.ScreperURLs", new[] { "ProductID" });
            DropTable("dbo.ScreperURLs");
        }
    }
}

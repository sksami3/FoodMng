namespace FoodMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Double(nullable: false),
                        Catagory_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Catagory", t => t.Catagory_id, cascadeDelete: true)
                .Index(t => t.Catagory_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "Catagory_id", "dbo.Catagory");
            DropIndex("dbo.Item", new[] { "Catagory_id" });
            DropTable("dbo.Item");
            DropTable("dbo.Catagory");
        }
    }
}

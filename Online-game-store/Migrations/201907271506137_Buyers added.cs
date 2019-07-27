namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buyersadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Games", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "Buyer_Id", c => c.Int());
            CreateIndex("dbo.Games", "Buyer_Id");
            AddForeignKey("dbo.Games", "Buyer_Id", "dbo.Buyers", "Id");
            DropColumn("dbo.Games", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Games", "Buyer_Id", "dbo.Buyers");
            DropIndex("dbo.Games", new[] { "Buyer_Id" });
            DropColumn("dbo.Games", "Buyer_Id");
            DropTable("dbo.Buyers");
            CreateIndex("dbo.Games", "ApplicationUser_Id");
            AddForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

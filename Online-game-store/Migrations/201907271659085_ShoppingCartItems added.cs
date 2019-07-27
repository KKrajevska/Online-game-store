namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartItemsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ShoppingCartId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "GameId", "dbo.Games");
            DropIndex("dbo.CartItems", new[] { "GameId" });
            DropTable("dbo.CartItems");
        }
    }
}

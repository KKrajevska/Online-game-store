namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            AddColumn("dbo.CartItems", "Ammount", c => c.Int(nullable: false));
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CartItems", "ShoppingCartId");
            AddForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "ShoppingCartId" });
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.Int(nullable: false));
            DropColumn("dbo.CartItems", "Ammount");
            DropTable("dbo.ShoppingCarts");
        }
    }
}

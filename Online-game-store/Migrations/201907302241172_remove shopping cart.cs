namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeshoppingcart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "ShoppingCartId" });
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String());
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            AlterColumn("dbo.CartItems", "ShoppingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CartItems", "ShoppingCartId");
            AddForeignKey("dbo.CartItems", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
        }
    }
}

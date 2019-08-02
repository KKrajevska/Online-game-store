namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Paymentmodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 50),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardType = c.String(nullable: false),
                        CreditCard = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}

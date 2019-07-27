namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Price", c => c.String());
            AlterColumn("dbo.Games", "Size", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Size", c => c.Single(nullable: false));
            AlterColumn("dbo.Games", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String());
        }
    }
}

namespace Online_game_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}

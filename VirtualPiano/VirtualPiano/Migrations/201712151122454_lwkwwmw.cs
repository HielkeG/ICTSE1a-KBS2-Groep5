namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lwkwwmw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "flipped", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signs", "flipped");
        }
    }
}

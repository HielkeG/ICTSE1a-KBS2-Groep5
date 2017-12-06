namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bars", "isFull");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bars", "isFull", c => c.Boolean(nullable: false));
        }
    }
}

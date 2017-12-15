namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mekekk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "sharp", c => c.Boolean());
            AddColumn("dbo.Signs", "flat", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signs", "flat");
            DropColumn("dbo.Signs", "sharp");
        }
    }
}

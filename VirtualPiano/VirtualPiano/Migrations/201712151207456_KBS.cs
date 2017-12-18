namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KBS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "sharp", c => c.Boolean());
            AddColumn("dbo.Signs", "flat", c => c.Boolean());
            AddColumn("dbo.Signs", "flipped", c => c.Boolean());
            AddColumn("dbo.Songs", "FlatSharp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "FlatSharp");
            DropColumn("dbo.Signs", "flipped");
            DropColumn("dbo.Signs", "flat");
            DropColumn("dbo.Signs", "sharp");
        }
    }
}

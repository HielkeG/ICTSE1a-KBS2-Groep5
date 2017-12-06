namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oijo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "x1", c => c.Int());
            AddColumn("dbo.Signs", "y1", c => c.Int());
            DropColumn("dbo.Bars", "isFull");
            DropColumn("dbo.Bars", "FlatSharp");
            DropColumn("dbo.Signs", "noteName");
            DropColumn("dbo.Signs", "restName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Signs", "restName", c => c.String());
            AddColumn("dbo.Signs", "noteName", c => c.String());
            AddColumn("dbo.Bars", "FlatSharp", c => c.Int(nullable: false));
            AddColumn("dbo.Bars", "isFull", c => c.Boolean(nullable: false));
            DropColumn("dbo.Signs", "y1");
            DropColumn("dbo.Signs", "x1");
        }
    }
}

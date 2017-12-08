namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hielke : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bars", "clefName", c => c.String(nullable: false));
            DropColumn("dbo.Bars", "clef");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bars", "clef", c => c.String(nullable: false));
            DropColumn("dbo.Bars", "clefName");
        }
    }
}

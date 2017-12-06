namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hielee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "x1", c => c.Int());
            AddColumn("dbo.Signs", "y1", c => c.Int());
            DropColumn("dbo.Signs", "noteName");
            DropColumn("dbo.Signs", "restName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Signs", "restName", c => c.String());
            AddColumn("dbo.Signs", "noteName", c => c.String());
            DropColumn("dbo.Signs", "y1");
            DropColumn("dbo.Signs", "x1");
        }
    }
}

namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksksks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Pages", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Pages");
        }
    }
}

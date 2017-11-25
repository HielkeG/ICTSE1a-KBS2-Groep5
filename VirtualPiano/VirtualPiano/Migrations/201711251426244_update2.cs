namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bars", "clef", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bars", "clef", c => c.Int(nullable: false));
        }
    }
}

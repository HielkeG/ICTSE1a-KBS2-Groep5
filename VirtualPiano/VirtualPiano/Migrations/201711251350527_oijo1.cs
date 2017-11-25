namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oijo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bars", "FlatSharp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bars", "FlatSharp");
        }
    }
}

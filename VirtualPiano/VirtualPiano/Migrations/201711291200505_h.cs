namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Signs", "FlatSharp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Signs", "FlatSharp", c => c.Int());
        }
    }
}

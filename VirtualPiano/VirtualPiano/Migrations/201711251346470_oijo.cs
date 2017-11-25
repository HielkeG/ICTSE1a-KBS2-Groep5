namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oijo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "FlatSharp", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signs", "FlatSharp");
        }
    }
}

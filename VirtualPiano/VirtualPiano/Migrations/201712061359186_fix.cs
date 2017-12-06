namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signs", "name");
        }
    }
}

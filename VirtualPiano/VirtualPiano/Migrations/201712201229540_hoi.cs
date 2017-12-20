namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "Y");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "Y", c => c.Int(nullable: false));
        }
    }
}

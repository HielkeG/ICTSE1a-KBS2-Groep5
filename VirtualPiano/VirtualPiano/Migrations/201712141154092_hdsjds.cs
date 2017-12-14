namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hdsjds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Signs", "ConnectionNote_SignId", "dbo.Signs");
            DropIndex("dbo.Signs", new[] { "ConnectionNote_SignId" });
            DropColumn("dbo.Signs", "ConnectionNote_SignId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Signs", "ConnectionNote_SignId", c => c.Int());
            CreateIndex("dbo.Signs", "ConnectionNote_SignId");
            AddForeignKey("dbo.Signs", "ConnectionNote_SignId", "dbo.Signs", "SignId");
        }
    }
}

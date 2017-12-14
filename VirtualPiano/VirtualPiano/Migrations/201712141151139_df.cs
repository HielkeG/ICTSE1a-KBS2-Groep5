namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signs", "ConnectionNote_SignId", c => c.Int());
            CreateIndex("dbo.Signs", "ConnectionNote_SignId");
            AddForeignKey("dbo.Signs", "ConnectionNote_SignId", "dbo.Signs", "SignId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Signs", "ConnectionNote_SignId", "dbo.Signs");
            DropIndex("dbo.Signs", new[] { "ConnectionNote_SignId" });
            DropColumn("dbo.Signs", "ConnectionNote_SignId");
        }
    }
}

namespace VirtualPiano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bars",
                c => new
                    {
                        BarId = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        clef = c.String(nullable: false),
                        duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarId)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Signs",
                c => new
                    {
                        SignId = c.Int(nullable: false, identity: true),
                        BarId = c.Int(nullable: false),
                        name = c.String(),
                        x = c.Int(),
                        y = c.Int(),
                        tone = c.String(),
                        octave = c.Int(),
                        x1 = c.Int(),
                        y1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SignId)
                .ForeignKey("dbo.Bars", t => t.BarId, cascadeDelete: true)
                .Index(t => t.BarId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        FlatSharp = c.Int(nullable: false),
                        y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Composer = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "SongId", "dbo.Songs");
            DropForeignKey("dbo.Bars", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Signs", "BarId", "dbo.Bars");
            DropIndex("dbo.Staffs", new[] { "SongId" });
            DropIndex("dbo.Signs", new[] { "BarId" });
            DropIndex("dbo.Bars", new[] { "StaffId" });
            DropTable("dbo.Songs");
            DropTable("dbo.Staffs");
            DropTable("dbo.Signs");
            DropTable("dbo.Bars");
        }
    }
}

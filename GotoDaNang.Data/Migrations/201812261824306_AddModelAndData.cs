namespace GotoDaNang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelAndData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                        PassWord = c.String(nullable: false, maxLength: 256, unicode: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Event = c.Boolean(),
                        Government = c.Boolean(),
                        Title = c.String(maxLength: 256),
                        Avatar = c.String(maxLength: 256),
                        Icon = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                        ServiceID = c.Int(nullable: false),
                        ProvincesID = c.Int(),
                        Tell = c.String(maxLength: 50, unicode: false),
                        Fax = c.String(maxLength: 256, unicode: false),
                        Aderess = c.String(maxLength: 500),
                        OpenTime = c.DateTime(nullable: false),
                        ClosingTime = c.DateTime(nullable: false),
                        Vote = c.Int(),
                        Website = c.String(),
                        FolderSlider = c.Boolean(),
                        HomeSlider = c.Boolean(),
                        Title = c.String(maxLength: 256),
                        Avatar = c.String(maxLength: 256),
                        Icon = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Provinces", t => t.ProvincesID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.ProvincesID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        CityID = c.Int(nullable: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SowAllCity = c.Boolean(),
                        Title = c.String(maxLength: 256),
                        Avatar = c.String(maxLength: 256),
                        Icon = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Places", "ProvincesID", "dbo.Provinces");
            DropForeignKey("dbo.Provinces", "CityID", "dbo.Cities");
            DropIndex("dbo.Services", new[] { "CategoryID" });
            DropIndex("dbo.Provinces", new[] { "CityID" });
            DropIndex("dbo.Places", new[] { "ProvincesID" });
            DropIndex("dbo.Places", new[] { "ServiceID" });
            DropTable("dbo.Services");
            DropTable("dbo.Provinces");
            DropTable("dbo.Places");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}

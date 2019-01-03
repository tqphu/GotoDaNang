namespace GotoDaNang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserRoles");
        }
    }
}

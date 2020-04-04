namespace GymApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroupUser",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GroupName = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppRole",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(),
                        PassWord = c.String(),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Active = c.Boolean(),
                        IsLock = c.Boolean(),
                        CountFail = c.Int(),
                        ResetKey = c.Guid(),
                        TimeExpire = c.DateTime(),
                        Avatar = c.String(),
                        LastPasswordChanged = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        IsAdmin = c.Boolean(),
                        ReturnUrl = c.String(),
                        AppGroupUserId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AppGroupUserId = c.Guid(nullable: false),
                        AppRoleId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppGroupUser", t => t.AppGroupUserId, cascadeDelete: true)
                .ForeignKey("dbo.AppRole", t => t.AppRoleId, cascadeDelete: true)
                .Index(t => t.AppGroupUserId)
                .Index(t => t.AppRoleId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 100),
                        State = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Credential", "AppRoleId", "dbo.AppRole");
            DropForeignKey("dbo.Credential", "AppGroupUserId", "dbo.AppGroupUser");
            DropIndex("dbo.Person", new[] { "CountryId" });
            DropIndex("dbo.Credential", new[] { "AppRoleId" });
            DropIndex("dbo.Credential", new[] { "AppGroupUserId" });
            DropTable("dbo.Person");
            DropTable("dbo.Credential");
            DropTable("dbo.Country");
            DropTable("dbo.AppUser");
            DropTable("dbo.AppRole");
            DropTable("dbo.AppGroupUser");
        }
    }
}

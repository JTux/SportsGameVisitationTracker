namespace StadiumTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameEntity",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        DateOfGame = c.DateTimeOffset(nullable: false, precision: 7),
                        HomeTeamWon = c.Boolean(nullable: false),
                        StadiumID = c.Int(nullable: false),
                        HomeTeamID = c.Int(nullable: false),
                        AwayTeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.TeamEntity", t => t.AwayTeamID, cascadeDelete: false)
                .ForeignKey("dbo.TeamEntity", t => t.HomeTeamID, cascadeDelete: false)
                .ForeignKey("dbo.StadiumEntity", t => t.StadiumID, cascadeDelete: true)
                .Index(t => t.StadiumID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID);
            
            CreateTable(
                "dbo.TeamEntity",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        LeagueID = c.Int(nullable: false),
                        ImageData = c.String(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.LeagueEntity", t => t.LeagueID, cascadeDelete: true)
                .Index(t => t.LeagueID);
            
            CreateTable(
                "dbo.LeagueEntity",
                c => new
                    {
                        LeagueID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        LeagueName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueID);
            
            CreateTable(
                "dbo.StadiumEntity",
                c => new
                    {
                        StadiumID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        StadiumName = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        StateName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StadiumID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.VisitorEntity",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorID);
            
            CreateTable(
                "dbo.VisitEntity",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        GotPin = c.Boolean(nullable: false),
                        TookPhoto = c.Boolean(nullable: false),
                        VisitorID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.GameEntity", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.VisitorEntity", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitEntity", "VisitorID", "dbo.VisitorEntity");
            DropForeignKey("dbo.VisitEntity", "GameID", "dbo.GameEntity");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GameEntity", "StadiumID", "dbo.StadiumEntity");
            DropForeignKey("dbo.GameEntity", "HomeTeamID", "dbo.TeamEntity");
            DropForeignKey("dbo.GameEntity", "AwayTeamID", "dbo.TeamEntity");
            DropForeignKey("dbo.TeamEntity", "LeagueID", "dbo.LeagueEntity");
            DropIndex("dbo.VisitEntity", new[] { "GameID" });
            DropIndex("dbo.VisitEntity", new[] { "VisitorID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TeamEntity", new[] { "LeagueID" });
            DropIndex("dbo.GameEntity", new[] { "AwayTeamID" });
            DropIndex("dbo.GameEntity", new[] { "HomeTeamID" });
            DropIndex("dbo.GameEntity", new[] { "StadiumID" });
            DropTable("dbo.VisitEntity");
            DropTable("dbo.VisitorEntity");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.StadiumEntity");
            DropTable("dbo.LeagueEntity");
            DropTable("dbo.TeamEntity");
            DropTable("dbo.GameEntity");
        }
    }
}

namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryFilm",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Metatitle = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Metatitle = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 1024),
                        Duration = c.Long(nullable: false),
                        Quality = c.String(),
                        View = c.Long(nullable: false),
                        LinkTrailer = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CategoryFilmID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryFilm", t => t.CategoryFilmID)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.CategoryFilmID);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FileType = c.Int(nullable: false),
                        FileContent = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(nullable: false),
                        Tag = c.String(),
                        Status = c.Boolean(nullable: false),
                        FilmID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Film", t => t.FilmID)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.FilmID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Name = c.String(maxLength: 4000),
                        BirthDay = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Phone = c.String(maxLength: 20),
                        Sex = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserID = c.Long(nullable: false),
                        FilmID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Film", t => t.FilmID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FilmID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryFilm", "UserID", "dbo.User");
            DropForeignKey("dbo.Film", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.File", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Rate", "UserID", "dbo.User");
            DropForeignKey("dbo.Rate", "FilmID", "dbo.Film");
            DropForeignKey("dbo.File", "FilmID", "dbo.Film");
            DropForeignKey("dbo.Film", "CategoryFilmID", "dbo.CategoryFilm");
            DropIndex("dbo.Rate", new[] { "FilmID" });
            DropIndex("dbo.Rate", new[] { "UserID" });
            DropIndex("dbo.File", new[] { "FilmID" });
            DropIndex("dbo.File", new[] { "CreatedBy" });
            DropIndex("dbo.Film", new[] { "CategoryFilmID" });
            DropIndex("dbo.Film", new[] { "CreatedBy" });
            DropIndex("dbo.CategoryFilm", new[] { "UserID" });
            DropTable("dbo.Rate");
            DropTable("dbo.User");
            DropTable("dbo.File");
            DropTable("dbo.Film");
            DropTable("dbo.CategoryFilm");
        }
    }
}

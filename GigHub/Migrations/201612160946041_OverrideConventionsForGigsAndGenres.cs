namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForGigsAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "ArtistId");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Gigs", "Genre_Id");
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id");
        }
    }
}

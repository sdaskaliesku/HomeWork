namespace HomeWork.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 64),
                        Gender = c.Boolean(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Year = c.DateTime(nullable: false),
                        DurationInSeconds = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesActors",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .ForeignKey("dbo.Actors", t => t.ActorId)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MoviesActors", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.MoviesActors", "MovieId", "dbo.Movies");
            DropIndex("dbo.MoviesActors", new[] { "ActorId" });
            DropIndex("dbo.MoviesActors", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.MoviesActors");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}

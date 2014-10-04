namespace HomeWork.Context
{
    using System.Data.Entity;
    using Models;
    public class HomeWorkEntitiesContext : DbContext 
    {

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genres>().HasKey(g => g.Id);
            modelBuilder.Entity<Genres>().Property(g => g.Name).HasMaxLength(64).IsRequired();

            modelBuilder.Entity<Movies>().HasKey(m => m.Id);
            modelBuilder.Entity<Movies>().Property(m => m.Title).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Movies>().Property(m => m.Year).IsRequired();
            modelBuilder.Entity<Movies>().Property(m => m.DurationInSeconds).IsRequired();
            modelBuilder.Entity<Movies>().Property(m => m.Year).IsRequired();
            modelBuilder.Entity<Movies>().HasRequired(m => m.Genres)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            modelBuilder.Entity<Actors>().HasKey(a => a.Id);
            modelBuilder.Entity<Actors>().Property(a => a.FirstName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Actors>().Property(a => a.LastName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Actors>().Property(a => a.Gender);
            modelBuilder.Entity<Actors>().Property(a => a.DateOfBirth).IsRequired();

            modelBuilder.Entity<Movies>()
                .HasMany(a => a.Actors)
                .WithMany(m => m.Movies)
                .Map(mc =>
                {
                    mc.ToTable("MoviesActors");
                    mc.MapLeftKey("MovieId");
                    mc.MapRightKey("ActorId");
                });

        }
    }
}
using Microsoft.EntityFrameworkCore;


namespace KOLOS.Models
{
    public class ArtistsDbContext : DbContext
    {
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Event_Organiser> Event_Organisers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist_Event> Artist_Events { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public ArtistsDbContext()
        {

        }

        public ArtistsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organiser>(opt =>
            {
                opt.HasKey(p => p.IdOrganiser);
                opt.Property(p => p.IdOrganiser)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();
            });

            modelBuilder.Entity<Event_Organiser>(opt =>
            {
                opt.HasKey(p => p.IdEvent);
                opt.Property(p => p.IdEvent);

                opt.HasKey(p => p.IdOrganiser);
                opt.Property(p => p.IdOrganiser);

                opt.HasOne(p => p.Event)
                .WithMany(p => p.Event_Organisers)
                .HasForeignKey(p => p.IdEvent);

                opt.HasOne(p => p.Organiser)
                .WithMany(p => p.Event_Organisers)
                .HasForeignKey(p => p.IdOrganiser);
            });

            modelBuilder.Entity<Event>(opt =>
            {
                opt.HasKey(p => p.IdEvent);
                opt.Property(p => p.IdEvent)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            });

            modelBuilder.Entity<Artist_Event>(opt =>
            {
                opt.HasKey(p => p.IdEvent);
                opt.Property(p => p.IdEvent);

                opt.HasKey(p => p.IdArtist);
                opt.Property(p => p.IdArtist);

                opt.HasOne(p => p.Event)
                .WithMany(p => p.Artist_Events)
                .HasForeignKey(p => p.IdEvent);

                opt.HasOne(p => p.Artist)
                .WithMany(p => p.Artist_Events)
                .HasForeignKey(p => p.IdArtist);
            });


            modelBuilder.Entity<Artist>(opt =>
            {
                opt.HasKey(p => p.IdArtist);
                opt.Property(p => p.IdArtist)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Nickname)
                .HasMaxLength(30)
                .IsRequired();
            });

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Media.Domain;

/// <summary>
/// Class MediaContext is used to work with database
/// </summary>
public sealed class MediaContext : DbContext
{
    /// <summary>
    /// Used to store a collection of albums
    /// </summary>
    public DbSet<Album> Albums { get; set; } = null!;

    /// <summary>
    /// Used to store a collection of artists
    /// </summary>
    public DbSet<Artist> Artists { get; set; } = null!;

    /// <summary>
    /// Used to store a collection of genres
    /// </summary>
    public DbSet<Genre> Genres { get; set; } = null!;

    /// <summary>
    /// Used to store a collection of tracks
    /// </summary>
    public DbSet<Track> Tracks { get; set; } = null!;

    public MediaContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
	/// Writes values ​​to the database
	/// </summary>
	/// <param name="modelBuilder">Model Builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            Id = 1,
            Name = "Genre #1",
        });
        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            Id = 1,
            Name = "Artist #1",
            Description = "Description of Artist #1"
        });
        modelBuilder.Entity<Album>().HasData(new Album
        {
            Id = 1,
            Name = "Album #1",
            Year = 2023,
            GenreId = 1,
            ArtistId = 1
        });
        for (var i = 1; i < 5; i++)
        {
            modelBuilder.Entity<Track>().HasData(new Track
            {
                Id = i,
                Number = i,
                Name = "Track #" + i,
                AlbumId = 1,
                Duration = ((i + 4) % 10) * 100
            });
        }
    }
}

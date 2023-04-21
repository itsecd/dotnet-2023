using Microsoft.EntityFrameworkCore;

namespace Media.Domain;

/// <summary>
/// Class MediaContext is used to work with database
/// </summary>
public sealed class MediaContext: DbContext
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
}

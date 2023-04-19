using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Domain;
public sealed class MediaContext: DbContext
{
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null;
    public DbSet<Track> Tracks { get; set; } = null;  
    
    public MediaContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}

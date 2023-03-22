using Media.Domain;

namespace Media.Server.Repository;
public interface IMediaRepository
{
    List<Album> Albums { get; }
    List<Artist> Artists { get; }
    List<Genre> Genres { get; }
    List<Track> Tracks { get; }
}
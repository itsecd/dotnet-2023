using Media.Domain;

namespace Media.Server;

public class MediaRepository
{
    public List<Genre> Genres { get; set; } = new() {new Genre {Id = 0, Name = "rock"},
                                                    new Genre {Id = 1, Name = "pop"} };


}

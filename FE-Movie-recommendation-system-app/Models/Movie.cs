using System.Collections.Generic;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public long ReleaseYear { get; set; }
    public long TmdbId { get; set; }
    public List<MovieGenre> Genres { get; set; } = new List<MovieGenre>();
}

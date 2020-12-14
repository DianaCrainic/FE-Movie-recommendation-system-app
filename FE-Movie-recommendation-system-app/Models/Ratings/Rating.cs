using System.Collections.Generic;
public class Rating
{
    public int Id { get; set; }
    public Movie Movie { get; set; }
    public User User { get; set; }
    public float Value { get; set; }
}

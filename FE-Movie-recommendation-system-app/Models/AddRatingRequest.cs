using System.ComponentModel.DataAnnotations;

public class AddRatingRequest
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public float Value { get; set; }
}

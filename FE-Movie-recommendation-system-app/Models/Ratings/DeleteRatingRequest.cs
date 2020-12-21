using System.ComponentModel.DataAnnotations;

public class DeleteRatingRequest
{
    public int MovieId { get; set; }
    public int userId { get; set; }

}

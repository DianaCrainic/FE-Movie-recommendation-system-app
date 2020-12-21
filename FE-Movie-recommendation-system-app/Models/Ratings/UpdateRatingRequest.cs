using System.ComponentModel.DataAnnotations;

public class UpdateRatingRequest
{
    public int MovieId { get; set; }
    public int userId { get; set; }

    [Range(ModelConstants.MinRatingValue, ModelConstants.MaxRatingValue)]
    public float Value { get; set; }
}

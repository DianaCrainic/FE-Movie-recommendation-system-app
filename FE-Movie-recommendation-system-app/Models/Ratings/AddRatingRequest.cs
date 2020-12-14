﻿using System.ComponentModel.DataAnnotations;

public class AddRatingRequest
{
    public int MovieId { get; set; }
    public int userId { get; set; }

    [Range(1.0, 5.0)]
    public float Value { get; set; }
}

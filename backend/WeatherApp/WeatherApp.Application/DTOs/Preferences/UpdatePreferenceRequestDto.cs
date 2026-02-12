using System.ComponentModel.DataAnnotations;

public class UpdatePreferenceRequest
{
    [Required]
    [RegularExpression("metric|imperial")]
    public string Units { get; set; }

    [Range(5, 1440)]
    public int RefreshIntervalMinutes { get; set; }
}

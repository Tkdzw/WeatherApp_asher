public class ForecastDto
{
    public DateTime Date { get; set; }

    public decimal MinTemperature { get; set; }
    public decimal MaxTemperature { get; set; }

    public string Description { get; set; }
    public string Icon { get; set; }
}

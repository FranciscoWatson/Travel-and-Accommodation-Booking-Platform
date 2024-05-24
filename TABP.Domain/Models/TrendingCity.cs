namespace TABP.Domain.Models;

public class TrendingCity
{
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public int VisitsCount { get; set; }
    
}
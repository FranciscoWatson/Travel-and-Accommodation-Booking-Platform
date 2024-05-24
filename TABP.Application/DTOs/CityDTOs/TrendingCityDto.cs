namespace TABP.Application.DTOs.CityDTOs;

public class TrendingCityDto
{
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public int VisitsCount { get; set; }
}
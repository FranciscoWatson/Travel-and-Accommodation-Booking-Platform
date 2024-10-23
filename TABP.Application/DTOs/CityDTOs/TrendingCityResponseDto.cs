namespace TABP.Application.DTOs.CityDTOs;

public class TrendingCityResponseDto
{
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public int VisitsCount { get; set; }
    public string? ThumbnailImage { get; set; }
}
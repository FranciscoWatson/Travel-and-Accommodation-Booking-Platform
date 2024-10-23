namespace TABP.Application.DTOs.CityDTOs;

public class CityDto
{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ThumbnailImage { get; set; }
    public string PostalCode { get; set; }
    public string CountryName { get; set; }
}
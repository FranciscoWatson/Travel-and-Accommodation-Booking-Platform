namespace TABP.Application.DTOs.CityDTOs;

public class CityForCreationRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ThumbnailImage { get; set; }
    public string PostalCode { get; set; }
    public Guid CountryId { get; set; }
}
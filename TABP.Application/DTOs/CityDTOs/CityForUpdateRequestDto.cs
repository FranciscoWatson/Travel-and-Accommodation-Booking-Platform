namespace TABP.Application.DTOs.CityDTOs;

public class CityForUpdateRequestDto
{
    public string Name { get; set; }
    public string PostalCode { get; set; }
    public Guid CountryId { get; set; }
}
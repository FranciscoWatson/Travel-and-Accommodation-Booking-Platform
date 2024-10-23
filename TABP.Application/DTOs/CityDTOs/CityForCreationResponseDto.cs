namespace TABP.Application.DTOs.CityDTOs;

public class CityForCreationResponseDto
{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
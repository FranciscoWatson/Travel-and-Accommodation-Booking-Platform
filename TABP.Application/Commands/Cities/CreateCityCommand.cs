using MediatR;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Commands.Cities;

public class CreateCityCommand : IRequest<CityForCreationResponseDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ThumbnailImage { get; set; }
    public string PostalCode { get; set; }
    public Guid CountryId { get; set; }
}
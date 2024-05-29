using MediatR;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Commands.Cities;

public class CreateCityCommand : IRequest<CityForCreationResponseDto>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string? ThumbnailImage { get; init; }
    public string PostalCode { get; init; }
    public Guid CountryId { get; init; }
}
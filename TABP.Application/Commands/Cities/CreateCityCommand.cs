using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Cities;

public class CreateCityCommand : IRequest<Result<CityForCreationResponseDto>>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string? ThumbnailImage { get; init; }
    public string PostalCode { get; init; }
    public Guid CountryId { get; init; }
}
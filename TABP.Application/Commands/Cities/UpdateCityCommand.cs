using MediatR;

namespace TABP.Application.Commands.Cities;

public class UpdateCityCommand : IRequest
{
    public Guid CityId { get; init; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    public Guid CountryId { get; set; }
}
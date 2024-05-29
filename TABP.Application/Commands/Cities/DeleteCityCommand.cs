using MediatR;

namespace TABP.Application.Commands.Cities;

public class DeleteCityCommand : IRequest
{
    public Guid CityId { get; set; }
}
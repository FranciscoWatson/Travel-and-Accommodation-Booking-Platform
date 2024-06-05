using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Cities;

public class DeleteCityCommand : IRequest<Result<object>>
{
    public Guid CityId { get; init; }
}
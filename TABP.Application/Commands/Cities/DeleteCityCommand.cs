using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Cities;

public class DeleteCityCommand : IRequest<Result>
{
    public Guid CityId { get; init; }
}
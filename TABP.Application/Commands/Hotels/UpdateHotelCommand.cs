using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Hotels;

public class UpdateHotelCommand : IRequest<Result<object>>
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public Guid OwnerId { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
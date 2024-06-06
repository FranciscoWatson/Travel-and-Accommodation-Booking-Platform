using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, Result<object>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public UpdateRoomHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<Result<object>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId);
        if (room == null)
        {
            return Result<object>.Fail($"Room with id {request.RoomId} not found.");
        }

        _mapper.Map(request, room);

        await _roomRepository.UpdateAsync(room);
        return Result<object>.Success();
    }
}


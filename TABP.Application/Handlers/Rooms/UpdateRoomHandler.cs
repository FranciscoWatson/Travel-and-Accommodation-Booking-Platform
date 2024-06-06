using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, Result<object>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public UpdateRoomHandler(IRoomRepository roomRepository, IMapper mapper, IRoomTypeRepository roomTypeRepository)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<Result<object>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomTypeExists = await _roomTypeRepository.ExistsAsync(request.RoomTypeId);
        if (!roomTypeExists)
        {
            return Result<object>.Fail("Room type not found.");
        }
        
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


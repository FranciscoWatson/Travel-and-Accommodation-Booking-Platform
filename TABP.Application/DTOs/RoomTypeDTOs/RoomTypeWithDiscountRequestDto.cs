namespace TABP.Application.DTOs.RoomTypeDTOs;

public class RoomTypeWithDiscountRequestDto
{
    public DateTime? CheckIn { get; set; } = DateTime.Now;
    public DateTime? CheckOut { get; set; } = DateTime.Now.AddDays(1);
}
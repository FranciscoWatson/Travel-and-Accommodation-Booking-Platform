namespace TABP.Application.DTOs.ReviewDTOs;

public class ReviewDto
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
}
using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IReviewRepository
{
    public Task<Review?> GetByIdAsync(Guid id);
    public Task<List<Review>> GetAllAsync();
    public Task<Review> CreateAsync(Review review);
    public Task UpdateAsync(Review review);
    public Task DeleteAsync(Guid id);
}
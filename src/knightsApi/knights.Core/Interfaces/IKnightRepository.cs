using Knights.Core.Entities;

namespace Knights.Core.Interfaces
{
    public interface IKnightRepository
    {
        Task<IEnumerable<Knight>> GetKnightsAsync();
        Task<IEnumerable<Knight>> GetKnightsByFilterAsync(string filter);
        Task<Knight> GetKnightByIdAsync(Guid id);
        Task AddKnightAsync(Knight knight);
        Task UpdateKnightAsync(Knight knight);
        Task DeleteKnightAsync(Guid id);
    }
}
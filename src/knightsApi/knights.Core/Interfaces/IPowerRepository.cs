using Knights.Core.Entities;

namespace Knights.Core.Interfaces
{
    public interface IPowerRepository
    {
        Task<IEnumerable<Power>> GetPowersAsync();
        Task<IEnumerable<Power>> GetPowersByFilterAsync(string filter);
        Task<Power> GetPowerByIdAsync(Guid id);
        Task AddPowerAsync(Power power);
        Task UpdatePowerAsync(Power power);
        Task DeletePowerAsync(Guid id);
    }
}
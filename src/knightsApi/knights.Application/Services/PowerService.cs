using Knights.Core.Entities;
using Knights.Core.Interfaces;

namespace Knights.Application.Services
{
    public class PowerService
    {
        private readonly IPowerRepository _powerRepository;

        public PowerService(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        public Task<IEnumerable<Power>> GetPowersAsync() => _powerRepository.GetPowersAsync();

        public Task<IEnumerable<Power>> GetPowersByFilterAsync(string filter) => _powerRepository.GetPowersByFilterAsync(filter);

        public Task<Power> GetPowerByIdAsync(Guid id) => _powerRepository.GetPowerByIdAsync(id);

        public Task AddPowerAsync(Power power) => _powerRepository.AddPowerAsync(power);

        public Task UpdatePowerAsync(Power power) => _powerRepository.UpdatePowerAsync(power);

        public Task DeletePowerAsync(Guid id) => _powerRepository.DeletePowerAsync(id);
    }
}
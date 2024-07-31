using Knights.Core.Entities;

namespace Knights.Core.Interfaces
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<Attributes>> GetAttributesAsync();
        Task<Attributes> GetAttributeByIdAsync(Guid id);
        Task AddAttributeAsync(Attributes attribute);
        Task UpdateAttributeAsync(Attributes attribute);
        Task DeleteAttributeAsync(Guid id);
    }
}
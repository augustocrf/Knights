using Knights.Core.Entities;
using Knights.Core.Interfaces;

namespace Knights.Application.Services
{
    public class AttributeService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeService(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public Task<IEnumerable<Attributes>> GetAttributesAsync() => _attributeRepository.GetAttributesAsync();

        public Task<Attributes> GetAttributeByIdAsync(Guid id) => _attributeRepository.GetAttributeByIdAsync(id);

        public Task AddAttributeAsync(Attributes attribute) => _attributeRepository.AddAttributeAsync(attribute);

        public Task UpdateAttributeAsync(Attributes attribute) => _attributeRepository.UpdateAttributeAsync(attribute);

        public Task DeleteAttributeAsync(Guid id) => _attributeRepository.DeleteAttributeAsync(id);
    }
}
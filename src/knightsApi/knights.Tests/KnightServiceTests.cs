using Knights.Application.Services;
using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Moq;

namespace Knights.Tests
{
    public class KnightServiceTests
    {
        private readonly Mock<IKnightRepository> _knightRepositoryMock;
        private readonly KnightService _knightService;

        public KnightServiceTests()
        {
            _knightRepositoryMock = new Mock<IKnightRepository>();
            _knightService = new KnightService(_knightRepositoryMock.Object);
        }

        [Fact]
        public async Task GetKnightsAsync_ReturnsKnights()
        {
            // Arrange
            var knights = new List<Knight> { new Knight { Name = "Test Knight" } };
            _knightRepositoryMock.Setup(repo => repo.GetKnightsAsync()).ReturnsAsync(knights);

            // Act
            var result = await _knightService.GetKnightsAsync();

            // Assert
            Assert.Equal(knights, result);
        }

        // Outros testes...
    }
}
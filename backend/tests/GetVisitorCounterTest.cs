using Microsoft.Extensions.Logging;
using NSubstitute;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using Api.Function;



namespace Api.Function.Tests.Unit
{
    public class GetVisitorCounterTests
    {
        private readonly GetVisitorCounter _sut;
        private readonly ILogger<GetVisitorCounter> _logger = NullLogger<GetVisitorCounter>.Instance;
        private readonly IVisitorCounterService _mockCounterService = Substitute.For<IVisitorCounterService>();

        public GetVisitorCounterTests()
        {
            _sut = new GetVisitorCounter(_logger, _mockCounterService);
        }

        [Fact]
        public async Task IncrementCounter_ShouldIncrementCount()
        {
            // Arrange
            var initialCounter = new Counter("index", 1);
            var expectedCounter = new Counter("index", 2);  // Expected count after increment

            // Mock the IncrementCounter method to return the updated counter
            _mockCounterService.IncrementCounter(Arg.Any<Counter>())
                .Returns(expectedCounter);

            // Create a mock HttpRequestData
            var req = Substitute.For<HttpRequestData>();

            // Act
            var result = await _sut.Run(req, initialCounter);  // Call the function

            // Assert
            result.NewCounter.Count.Should().Be(2);  // Ensure the count was incremented
            result.NewCounter.Should().BeEquivalentTo(expectedCounter);  // Ensure the returned counter matches the expected one
        }
    }
}

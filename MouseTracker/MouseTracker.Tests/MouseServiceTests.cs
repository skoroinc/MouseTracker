using Moq;
using Xunit;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using MouseTracker.Application.DTOs;
using MouseTracker.Application.Services;
using MouseTracker.Domain.Entities;
using MouseTracker.Domain.Interfaces;
using System.Diagnostics;

namespace MouseTracker.Tests
{
    public class MouseServiceTests
    {

        [Fact]
        public async Task SaveMovementAsync_SavesDataCorrectly()
        {
            var mockRepo = new Mock<IRepository<MouseMovement>>();
            var service = new MouseService(mockRepo.Object);

            
            var coordinates = new List<CoordinateDto>
        {
            new(10, 20, 0), 
            new(30, 40, 0)
        };

            MouseMovement? savedMovement = null;

            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<MouseMovement>()))
                    .Callback<MouseMovement>(m => savedMovement = m);

            await service.SaveMovementAsync(coordinates);

            Assert.NotNull(savedMovement);
            var deserializedData = JsonSerializer.Deserialize<List<CoordinateDto>>(savedMovement!.Data);
            Assert.NotNull(deserializedData);
            Assert.Equal(2, deserializedData.Count);
            Assert.Equal(10, deserializedData[0].X);
            Assert.Equal(20, deserializedData[0].Y);

            
            var expectedTime = 0; 
            Assert.InRange(deserializedData[0].T, expectedTime - 1000, expectedTime + 1000); 

            Assert.Equal(30, deserializedData[1].X);
            Assert.Equal(40, deserializedData[1].Y);
            Assert.InRange(deserializedData[1].T, expectedTime - 1000, expectedTime + 1000);  

            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<MouseMovement>()), Times.Once);
        }
    }
}

using MouseTracker.Application.DTOs;
using MouseTracker.Application.Interfaces;
using MouseTracker.Domain.Entities;
using MouseTracker.Domain.Interfaces;
using System.Text.Json;

namespace MouseTracker.Application.Services
{
    public class MouseService : IMouseService
    {
        private readonly IRepository<MouseMovement> _repository;

        public MouseService(IRepository<MouseMovement> repository)
        {
            _repository = repository;
        }

        public async Task SaveMovementAsync(List<CoordinateDto> coordinates)
        {
            var jsonData = JsonSerializer.Serialize(coordinates);
            var movement = new MouseMovement { Data = jsonData };
            await _repository.AddAsync(movement);
        }
    }
}

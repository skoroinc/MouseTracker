using MouseTracker.Application.DTOs;
using MouseTracker.Application.Interfaces;
using MouseTracker.Domain.Entities;
using MouseTracker.Domain.Interfaces;
using System.Text.Json;
using System.Diagnostics;

namespace MouseTracker.Application.Services
{
    public class MouseService : IMouseService
    {
        private readonly IRepository<MouseMovement> _repository;
        private static readonly Stopwatch _stopwatch = new Stopwatch();

        static MouseService()
        {
            _stopwatch.Start(); 
        }

        public MouseService(IRepository<MouseMovement> repository)
        {
            _repository = repository;
        }

        public async Task SaveMovementAsync(List<CoordinateDto> coordinates)
        {
            
            var updatedCoordinates = coordinates.Select(c => new CoordinateDto(c.X, c.Y, GetElapsedTime())).ToList();

            var jsonData = JsonSerializer.Serialize(updatedCoordinates);
            var movement = new MouseMovement { Data = jsonData };
            await _repository.AddAsync(movement);
        }

        
        private static long GetElapsedTime()
        {
            return _stopwatch.ElapsedMilliseconds; 
        }
    }
}

using MouseTracker.Application.DTOs;

namespace MouseTracker.Application.Interfaces
{
    public interface IMouseService
    {
        Task SaveMovementAsync(List<CoordinateDto> coordinates);
    }
}

using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.DTOs;
using MouseTracker.Application.Interfaces;

namespace MouseTracker.Web.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IMouseService _mouseService;

        public HomeController(IMouseService mouseService)
        {
            _mouseService = mouseService;
        }

        [HttpGet("/")]
        public IActionResult Index() => View();

        [HttpPost("/api/mouse-data")]
        public async Task<IActionResult> SaveMouseData([FromBody] List<CoordinateDto> coordinates)
        {
            await _mouseService.SaveMovementAsync(coordinates);
            return Ok();
        }
    }
}

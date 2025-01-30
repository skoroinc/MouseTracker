namespace MouseTracker.Domain.Entities
{
    public class MouseMovement
    {
        public int Id { get; set; }
        public string Data { get; set; } // JSON данные
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

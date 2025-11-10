using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.CityServices
{
    public class TransportSchedule : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid RouteId { get; set; }
        public TransportRoute Route { get; set; } = null!;

        public TimeOnly DepartureTime { get; set; }
        public TimeOnly? ArrivalTime { get; set; }

        public int? FrequencyMinutes { get; set; }

        public string? DaysOfWeek { get; set; } // JSON array (as string)

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

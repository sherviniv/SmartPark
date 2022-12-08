using SmartPark.Application.Common.Interfaces;

namespace SmartPark.Infrastructure.Services.DateTimeService;
public class DateTimeService : IDateTime
{
    public DateTime UTCNow
    {
        get
        {
            return DateTime.UtcNow;
        }
    }
}
using LLS.Domain.Interfaces;

namespace LLS.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now() => DateTime.Now;
}
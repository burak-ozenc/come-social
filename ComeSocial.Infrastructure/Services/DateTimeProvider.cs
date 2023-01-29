using ComeSocial.Application.Common.Interfaces.Services;

namespace ComeSocial.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}
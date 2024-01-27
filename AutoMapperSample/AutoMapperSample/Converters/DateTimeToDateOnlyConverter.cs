using AutoMapper;

namespace AutoMapperSample.Converters;

public class DateTimeToDateOnlyConverter : IValueConverter<DateTime, DateOnly>
{
    public DateOnly Convert(DateTime dateTime, ResolutionContext context)
    {
        return DateOnly.FromDateTime(dateTime);
    }
}
namespace Bookify.Domain.Bookings.ValueObjects;

public record DateRange
{
    private DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException($"Start date {start} must be before end date {end}");
        }

        return new DateRange(start, end);
    }
}
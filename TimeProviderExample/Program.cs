var office = new Office(TimeProvider.System);
Console.WriteLine("Office is open is " + office.IsOpen());
public class Office
{
    private readonly TimeProvider _timeProvider;
    public Office(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public bool IsOpen()
    {
        var now = _timeProvider.GetLocalNow();
        List<DayOfWeek> weekDays = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        return weekDays.Contains(now.DayOfWeek) && now.Hour >= 8 && now.Hour <= 17;
    }
}
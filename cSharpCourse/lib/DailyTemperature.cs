namespace cSharpCourse.lib;

public record DailyTemperature(double HighTemp, double LowTemp)
{
    public double AverageTemp()
    {
        return (HighTemp + LowTemp) / 2.0;
    }
}

class TemperatureAnalyzer
{
    private DailyTemperature[] _dailyTemperature { get; set; } = [];
    public DailyTemperature[] DailyTemperature
    {
        get => _dailyTemperature;
        set => _dailyTemperature = value;
    }

    public void AddDailyTemperature(DailyTemperature temp)
    {
        var tempList = _dailyTemperature.ToList();
        tempList.Add(temp);
        _dailyTemperature = tempList.ToArray();
    }

    public int GetTotalDays() => _dailyTemperature.Length;

    public (double AverageTemperature, int TotalDays) GetAverageTemperature()
    {
        return (_dailyTemperature.Average(temp => temp.AverageTemp()), _dailyTemperature.Length);
    }
}

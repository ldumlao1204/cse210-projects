using System;

public class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected string Date => _date;
    protected int Minutes => _minutes;

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    protected virtual string GetActivityType()
    {
        return "Unknown Activity";
    }

    public virtual string GetSummary()
    {
        return $"{_date} {GetActivityType()} ({_minutes} min): Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}
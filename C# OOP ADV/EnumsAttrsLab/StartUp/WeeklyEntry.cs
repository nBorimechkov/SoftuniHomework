﻿using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay => this.weekDay;
    public string Notes { get; private set; }
    public override string ToString() => $"{this.weekDay} - {this.Notes}";

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekDayComparion = weekDay.CompareTo(other.weekDay);
        if (weekDayComparion != 0) return weekDayComparion;
        return string.Compare(Notes, other.Notes, StringComparison.Ordinal);
    }
}


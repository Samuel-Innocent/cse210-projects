using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            return GetPoints() + _bonus;
        }
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_targetCount}|{_currentCount}";
    }

    public int GetCurrentCount() => _currentCount;
    public int GetTargetCount() => _targetCount;
}

using System.Collections.Generic;

public class Skill
{
    private string name;
    private List<Constants.StatType> stats;
    private int points;

    public Skill(string _name, Constants.StatType _statType0, Constants.StatType _statType1, Constants.StatType _statType2)
    {
        name = _name;

        stats = new List<Constants.StatType>();
        stats.Add(_statType0);
        stats.Add(_statType1);
        stats.Add(_statType2);

        points = 0;
    }

    public string getName()
    {
        return name;
    }

    public int getPoints()
    {
        return points;
    }

    public List<Constants.StatType> getStats()
    {
        return stats;
    }

    public void setPoints(int newValue)
    {
        points = newValue;
    }
}

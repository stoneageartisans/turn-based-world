public class PrimaryStat
{
    private string name;
    private int baseValue;
    private int minimum;
    private int maximum;
    private int modifier;

    public PrimaryStat(string _name, int _baseValue, int _minimum, int _maximum)
    {
        name = _name;
        baseValue = _baseValue;
        minimum = _minimum;
        maximum = _maximum;
        modifier = 0;
    }

    public int getBaseValue()
    {
        return baseValue;
    }

    public int getCurrentValue()
    {
        return (baseValue + modifier);
    }

    public float getCurrentValueAsFloat()
    {
        return ((float) (baseValue + modifier));
    }

    public int getMaximum()
    {
        return maximum;
    }

    public int getMinimum()
    {
        return minimum;
    }

    public int getModifier()
    {
        return modifier;
    }

    public string getName()
    {
        return name;
    }    

    public void setBaseValue(int newValue)
    {
        baseValue = newValue;
    }

    public void setMaximum(int newValue)
    {
        maximum = newValue;
    }

    public void setMinimum(int newValue)
    {
        minimum = newValue;
    }

    public void setModifier(int newValue)
    {
        modifier = newValue;
    }
}

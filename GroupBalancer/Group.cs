public class Group
{
    public string Name { get; set; }
    public int CurrentCount { get; set; }
    public double TargetPercentage { get; set; }

    public double CalculateIdealCount(int totalItems)
    {
        return TargetPercentage * totalItems / 100;
    }

    public double CalculateDeviation(int totalItems)
    {
        return CalculateIdealCount(totalItems) - CurrentCount;
    }
}
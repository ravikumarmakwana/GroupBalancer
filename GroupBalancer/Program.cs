public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, double> groups = new Dictionary<string, double>
        {
            { "Group 1", 20 },
            { "Group 2", 30 },
            { "Group 3", 50 },
        };

        GroupBalancer groupBalancer = new(groups);

        // Simulate continuous assignment of peoples
        for (int i = 0; i < 102; i++)
        {
            groupBalancer.AssignPerson();
        }

        groupBalancer.Display();
    }
}
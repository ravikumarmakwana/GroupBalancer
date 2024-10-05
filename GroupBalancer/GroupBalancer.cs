public class GroupBalancer
{
    // Max Heap Implementation
    private readonly PriorityQueue<Group, double> _priorityQueue;

    private readonly List<Group> _groups;
    private int _totalPeople = 0;

    public GroupBalancer(Dictionary<string, double> groupPercentages)
    {
        _priorityQueue = new PriorityQueue<Group, double>();
        _groups = new List<Group>(); 

        foreach (var entry in groupPercentages)
        {
            var group = new Group { Name = entry.Key, TargetPercentage = entry.Value };
            _priorityQueue.Enqueue(group, -group.CalculateDeviation(_totalPeople)); 
            _groups.Add(group); 
        }
    }

    public void AssignPerson()
    {
        _totalPeople++;

        // Dequeue the group with the highest deviation / the one who furthest behind its ideal target count.
        Group group = _priorityQueue.Dequeue();
        group.CurrentCount++;

        Console.WriteLine($"Person {_totalPeople} assigned to Group {group.Name}");

        // Using negative to ensure max-heap behavior.
        _priorityQueue.Enqueue(group, -group.CalculateDeviation(_totalPeople));
    }

    public void Display()
    {
        Console.WriteLine("********************");
        Console.WriteLine("Resource Allocation: ");
        Console.WriteLine($"Total: {_totalPeople}");

        foreach (var group in _groups)
        {
            Console.WriteLine($"{group.Name}({group.TargetPercentage}%): {group.CurrentCount}");
        }
    }
}

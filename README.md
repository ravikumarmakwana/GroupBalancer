# GroupBalancer

GroupBalancer is a C# utility designed to dynamically allocate individuals into groups based on predefined target percentages. The goal is to continuously assign people to groups in a way that maintains the closest possible ratio to the desired distribution.

## Features

- **Dynamic Group Balancing:** Groups are assigned individuals in real-time while maintaining a target percentage distribution.
- **Priority Queue Based:** Uses a max heap to ensure that each group that is furthest behind its target receives the next person.
- **Configurable Group Percentages:** The number of groups and their respective percentage targets are flexible and can be adjusted through a simple dictionary.
- **Real-time Assignment:** The program tracks the number of people assigned to each group, adjusting dynamically as people are continuously added.

## Code Overview

### Group Class

Represents each group with the following properties:

- **Name:** The name of the group.
- **CurrentCount:** The number of people currently assigned to the group.
- **TargetPercentage:** The ideal percentage of people the group should contain.
- **CalculateIdealCount():** Calculates the ideal number of people for the group based on the total number of people assigned so far.
- **CalculateDeviation():** Calculates how far the group is from its ideal count.

### GroupBalancer Class

Manages the group assignment process:

- Uses a `PriorityQueue` to keep track of groups based on their deviation from their ideal count.
- Continuously assigns people to the group with the highest deviation.
- Displays the final group counts after assignments.

## How It Works

1. Initialize `GroupBalancer` with a dictionary containing group names and their target percentages.
2. Continuously assign individuals using the `AssignPerson` method.
3. Call `Display` to show the current distribution of people across the groups.

## Example

Below is an example of initializing and using `GroupBalancer`:

```csharp
Dictionary<string, double> groups = new Dictionary<string, double>
{
    { "Group 1", 20 },
    { "Group 2", 30 },
    { "Group 3", 50 }
};
// Total: 100%

GroupBalancer groupBalancer = new(groups);

// Simulate continuous assignment of people
for (int i = 0; i < 102; i++)
{
    groupBalancer.AssignPerson();
}

groupBalancer.Display();
```

## Output
```
Person 1 assigned to Group 1
Person 2 assigned to Group 2
Person 3 assigned to Group 3
...

Resource Allocation: 
Total: 102
Group 1 (20%): 19
Group 2 (30%): 32
Group 3 (50%): 51
```

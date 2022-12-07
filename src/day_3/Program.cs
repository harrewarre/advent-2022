// Part 1
var backpacks = File.ReadLines("input.txt")
    .Select((backpack) =>
    {
        var itemCount = backpack.Length;
        var compartmentSize = itemCount / 2;

        var compartmentOne = backpack.Substring(0, compartmentSize);
        var compartmentTwo = backpack.Substring(compartmentSize);

        var dupes = compartmentOne.Intersect(compartmentTwo);
        var priorities = dupes.Select(d => new { Dupe = d, Priority = GetItemPriority(d) }).ToArray();

        return  new { Dupes = priorities, CompartmentOne = compartmentOne, CompartmentTwo = compartmentTwo };
    });

var total = backpacks.Select(bp => bp.Dupes.Sum(d => d.Priority)).Sum();
Console.WriteLine($"Total priority value {total}");

// Part 2
var groups = File.ReadLines("input.txt")
    .Chunk(3)
    .Select((group) => {
        var first = group.First();
        var second = group.Skip(1).Take(1).First();
        var third = group.Last();

        var firstIntersect = first.Intersect(second);
        var secondIntersect = firstIntersect.Intersect(third);

        return firstIntersect.Intersect(secondIntersect).First();
    }).Select((item) => {
        return new {
            Item = item,
            Priority = GetItemPriority(item)
        };
    });

var totalGroupPriority = groups.Sum(g => g.Priority);
Console.WriteLine($"Total priority among all groups is {totalGroupPriority}");

int GetItemPriority(char item)
{
    var isUpper = char.IsUpper(item);
    var position = char.ToUpper(item) - 64;

    var priority = isUpper 
        ? position + 26 
        : position;

    return priority;
}
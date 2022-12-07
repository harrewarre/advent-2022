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

int GetItemPriority(char item)
{
    var isUpper = char.IsUpper(item);
    var position = char.ToUpper(item) - 64;

    var priority = isUpper 
        ? position + 26 
        : position;

    return priority;
}

var total = backpacks.Select(bp => bp.Dupes.Sum(d => d.Priority)).Sum();
Console.WriteLine($"Total priority value {total}");
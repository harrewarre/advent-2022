using System;
using System.IO;
using System.Linq;

var accumulator = 0;
var elves = Enumerable.Empty<Elf>();

foreach (var line in File.ReadLines("input.txt"))
{
    if (int.TryParse(line, out int calories))
    {
        var snackValue = int.Parse(line);
        accumulator = accumulator + snackValue;
    }
    else
    {
        elves = elves.Append(new Elf(accumulator));

        accumulator = 0;
    }
}

Console.WriteLine($"Found {elves.Count()} Elves!");


// Part 1:
var fatElfCalories = elves.Max(elf => elf.Calories);
Console.WriteLine($"The elf with the biggest stack carries {fatElfCalories} calories!");

// Part 2:
var top3Calories = elves.OrderByDescending(elf => elf.Calories).Take(3).Sum(elf => elf.Calories);
Console.WriteLine($"The top 3 elves carry a combined total of {top3Calories} calories!");

public class Elf
{
    public int Calories { get; private set; }

    public Elf(int calories)
    {
        Calories = calories;
    }
}
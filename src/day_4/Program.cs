// Part 1
var containedPairs = File.ReadLines("input.txt")
    .Select((line) => {
        var elves = line.Split(",");
        
        var sectionOne = elves.First().Split("-");
        var sectionTwo = elves.Last().Split("-");

        return new {
            SectionOneStart = int.Parse(sectionOne.First()),
            SectionOneEnd = int.Parse(sectionOne.Last()),
            SectionTwoStart = int.Parse(sectionTwo.First()),
            SectionTwoEnd = int.Parse(sectionTwo.Last())
        };
    }).Where(p => (p.SectionOneStart >= p.SectionTwoStart && p.SectionOneEnd <= p.SectionTwoEnd) || (p.SectionTwoStart >= p.SectionOneStart && p.SectionTwoEnd <= p.SectionOneEnd));

Console.WriteLine($"Found {containedPairs.Count()} duplicated sections!");

// Part 2
var overlappingPairs = File.ReadLines("input.txt")
    .Select((line) => {
        var elves = line.Split(",");
        
        var sectionOne = elves.First().Split("-");
        var sectionTwo = elves.Last().Split("-");

        return new {
            SectionOneStart = int.Parse(sectionOne.First()),
            SectionOneEnd = int.Parse(sectionOne.Last()),
            SectionTwoStart = int.Parse(sectionTwo.First()),
            SectionTwoEnd = int.Parse(sectionTwo.Last())
        };
    }).Where((pair) => {
        var sectionOne = Enumerable.Range(pair.SectionOneStart, pair.SectionOneEnd - pair.SectionOneStart + 1);
        var sectionTwo = Enumerable.Range(pair.SectionTwoStart, pair.SectionTwoEnd - pair.SectionTwoStart + 1);

        var intersects = sectionOne.Intersect(sectionTwo);

        return intersects.Any();
    });

Console.WriteLine($"Found {overlappingPairs.Count()} overlapping sections!");
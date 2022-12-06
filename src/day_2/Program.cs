// Them             Us
// A -> Rock (1)      -> X
// B -> Paper (2)     -> Y
// C -> Scissors (3)  -> Z

// Strat: Win (6) Lose (0) Draw (3)

string ROCK = "A";
string PAPER = "B";
string SCISSORS = "C";

string LOSE = "X";
string DRAW = "Y";
string WIN = "Z";

var finalScore = 0;

var rounds = File.ReadLines("input.txt")
    .Select((line) =>
    {
        var play = line.Split(' ');
        return new { Them = play[0], Us = play[1] };
    });

Console.WriteLine($"Playing {rounds.Count()} rounds...");

foreach (var round in rounds)
{
    finalScore += GetRoundScore(round.Them, round.Us);
}

Console.WriteLine($"Final score according to strategy: {finalScore} points!");

int GetRoundScore(string them, string us)
{
    var roundScore = 0;
    
    var ourPlay = PickOwnMove(them, us);

    if (us == WIN) { roundScore += 6; }
    if (us == LOSE) { roundScore += 0; }
    if (us == DRAW) { roundScore += 3; }

    if (ourPlay == ROCK) { roundScore += 1; }
    if (ourPlay == PAPER) { roundScore += 2; }
    if (ourPlay == SCISSORS) { roundScore += 3; }

    return roundScore;
}

string PickOwnMove(string them, string us)
{
    var ourMove = "";

    if (them == ROCK && us == WIN) { ourMove = PAPER; }
    if (them == ROCK && us == LOSE) { ourMove = SCISSORS; }
    if (them == ROCK && us == DRAW) { ourMove = ROCK; }

    if (them == PAPER && us == WIN) { ourMove = SCISSORS; }
    if (them == PAPER && us == LOSE) { ourMove = ROCK; }
    if (them == PAPER && us == DRAW) { ourMove = PAPER; }

    if (them == SCISSORS && us == WIN) { ourMove = ROCK; }
    if (them == SCISSORS && us == LOSE) { ourMove = PAPER; }
    if (them == SCISSORS && us == DRAW) { ourMove = SCISSORS; }

    return ourMove;
}
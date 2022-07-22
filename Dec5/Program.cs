using Dec5;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	int maxSeat = 0;
	foreach(string thisLine in allLines)
	{
		var thisSeat = new Seat(thisLine);
		maxSeat = Math.Max(maxSeat, thisSeat.GetSeatID());
	}
	Console.WriteLine($"Part 1: {maxSeat}");
}

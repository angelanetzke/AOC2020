using Dec11;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theRoom = new Room(allLines);
	int occupiedCount = theRoom.CountOccupied();
	Console.WriteLine($"Part 1: {occupiedCount}");
}
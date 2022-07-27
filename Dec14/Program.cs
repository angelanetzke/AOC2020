using Dec14;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theMemory = new Memory();
	foreach (string thisLine in allLines)
	{
		theMemory.Next(thisLine);
	}
	long sum = theMemory.GetSum();
	Console.WriteLine($"Part 1: {sum}");
}
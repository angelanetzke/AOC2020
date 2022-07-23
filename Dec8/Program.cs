using Dec8;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theBootCode = new BootCode(allLines);
	int acc = theBootCode.GetLastAcc();
	Console.WriteLine($"Part 1: {acc}");
}

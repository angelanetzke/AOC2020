using Dec6;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var currentForm = new Form();
	int totalYes = 0;
	foreach (string thisLine in allLines)
	{
		if (thisLine.Length == 0)
		{
			totalYes += currentForm.GetYesCount();
			currentForm = new Form();
		}
		else
		{
			currentForm.ProcessLine(thisLine);
		}
	}
	//Add final Form
	totalYes += currentForm.GetYesCount();
	Console.WriteLine($"Part 1: {totalYes}");
}

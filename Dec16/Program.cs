using Dec16;
using System.Text.RegularExpressions;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	List<string> rules = new();
	var ruleRegex = new Regex(@"^[a-z ]+: \d+-\d+ or \d+-\d+$");
	var ticketRegex = new Regex(@"^[\d+,]+$");
	int errorRate = 0;
	foreach (string thisLine in allLines)
	{
		if (ruleRegex.IsMatch(thisLine))
		{
			rules.Add(thisLine);
		}
		if (ticketRegex.IsMatch(thisLine))
		{
			errorRate += (new Ticket(thisLine, rules)).GetErrorRate();
		}
	}
	Console.WriteLine($"Part 1: {errorRate}");
}
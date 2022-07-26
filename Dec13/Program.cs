var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	int startTime = int.Parse(allLines[0]);
	var buses = allLines[1].Split(',');
	int earliestBusNumber = -1;
	int earliestBusTime = int.MaxValue;
	foreach (string thisBusString in buses)
	{
		if (thisBusString != "x")
		{
			int thisBusNumber = int.Parse(thisBusString);
			if (startTime % thisBusNumber == 0)
			{
				earliestBusNumber = thisBusNumber;
				earliestBusTime = startTime;
				break;
			}
			else
			{
				int thisNextBusTime = thisBusNumber * (startTime / thisBusNumber + 1);
				Console.WriteLine($"{thisNextBusTime} {thisBusNumber}");
				if (thisNextBusTime < earliestBusTime)
				{
					earliestBusNumber = thisBusNumber;
					earliestBusTime = thisNextBusTime;
				}
			}
		}
	}
	int part1Answer = earliestBusNumber * (earliestBusTime - startTime);
	Console.WriteLine($"Part 1: {part1Answer}");
}

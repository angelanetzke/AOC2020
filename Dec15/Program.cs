var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var startingNumbers = Array.ConvertAll(allLines[0].Split(','), thisString => int.Parse(thisString));
	var lastNumberIndices = new Dictionary<int, List<int>>();
	int lastNumber = 0;
	for (int i = 1; i <= 2020; i++)
	{
		if (i - 1 < startingNumbers.Length)
		{
			lastNumberIndices[startingNumbers[i - 1]] = new List<int> { i };
			lastNumber = startingNumbers[i - 1];
		}
		else
		{
			if (lastNumberIndices.TryGetValue(lastNumber, out List<int>? previous))
			{
				if (previous.Count == 1)
				{
					lastNumber = 0;
					Update(i, 0, lastNumberIndices);
				}
				else
				{
					int thisNumber = previous[1] - previous[0];
					lastNumber = thisNumber;
					Update(i, thisNumber, lastNumberIndices);
				}
			}
		}
	}
	Console.WriteLine($"Part 1: {lastNumber}");
}

static void Update(int turn, int value, Dictionary<int, List<int>> theDictionary)
{
	if (theDictionary.TryGetValue(value, out List<int>? list))
	{
		if (list.Count == 1)
		{
			theDictionary[value] = new List<int> { list[0], turn };
		}
		else
		{
			theDictionary[value] = new List<int> { list[1], turn };
		}
	}
	else
	{
		theDictionary[value] = new List<int> { turn };
	}
}
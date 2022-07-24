var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var numbers = new long[allLines.Length];
	for (int i = 0; i < allLines.Length; i++)
	{
		numbers[i] = long.Parse(allLines[i]);
	}
	int checkIndex = 25;	
	while(checkIndex < numbers.Length)
	{
		bool isValid = false;
		for (int i = checkIndex - 25; i <= checkIndex - 2; i++)
		{
			for (int j = checkIndex - 24; j <= checkIndex - 1; j++)
			{
				if (numbers[i] + numbers[j] == numbers[checkIndex])
				{
					isValid = true;
					break;
				}
			}
			if (isValid)
			{
				break;
			}
		}
		if (isValid)
		{
			checkIndex++;
		}
		else
		{
			long invalidNumber = numbers[checkIndex];
			Console.WriteLine($"Part 1: {invalidNumber}");
			return;
		}		
	}
}
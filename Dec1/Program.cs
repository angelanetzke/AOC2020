var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	for (int i = 0; i < allLines.Length - 1; i++)
	{
		for (int j = 1; j < allLines.Length; j++)
		{
			long number1 = long.Parse(allLines[i]);
			long number2 = long.Parse(allLines[j]);
			if (number1 + number2 == 2020L)
			{
				long product = number1 * number2;
				Console.WriteLine($"Part 1: {product}");
				return;
			}
		}
	}
}

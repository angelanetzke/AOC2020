var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var numbers = new List<int>();
	foreach(string thisLine in allLines)
	{
		numbers.Add(int.Parse(thisLine));
	}
	numbers.Sort();
	int jolt1DifferenceCount = 0;
	//start at 1 for device
	int jolt3DifferenceCount = 1;
	//Count difference between outlet and first adapter
	if (numbers[0] == 1)
	{
		jolt1DifferenceCount++;
	}
	if (numbers[0] == 3)
	{
		jolt3DifferenceCount++;
	}
	for (int i = 1; i < numbers.Count; i++)
	{
		if (numbers[i] - numbers[i - 1] == 1)
		{
			jolt1DifferenceCount++;
		}
		if (numbers[i] - numbers[i - 1] == 3)
		{
			jolt3DifferenceCount++;
		}
	}
	int answer = jolt1DifferenceCount * jolt3DifferenceCount;
	Console.WriteLine($"Part 1: {answer}");
}

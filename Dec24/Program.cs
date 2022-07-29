using Dec24;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var tiles = new Dictionary<Tile, bool>();
	foreach (string thisLine in allLines)
	{
		int x = 0;
		int y = 0;
		int cursor = 0;
		while (cursor < thisLine.Length)
		{
			if (thisLine[cursor] == 'e')
			{
				x += 10;
				cursor++;
			}
			else if (thisLine[cursor] == 's')
			{
				cursor++;
				if (thisLine[cursor] == 'e')
				{
					x += 5;
					y += 5;
					cursor++;
				}
				else if (thisLine[cursor] == 'w')
				{
					x -= 5;
					y += 5;
					cursor++;
				}
			}
			else if (thisLine[cursor] == 'w')
			{
				x -= 10;
				cursor++;
			}
			else if (thisLine[cursor] == 'n')
			{
				cursor++;
				if (thisLine[cursor] == 'e')
				{
					x += 5;
					y -= 5;
					cursor++;
				}
				else if (thisLine[cursor] == 'w')
				{
					x -= 5;
					y -= 5;
					cursor++;
				}
			}
		}
		var thisTile = new Tile(x, y);
		if (tiles.TryGetValue(thisTile, out bool isBlack))
		{
			tiles[thisTile] = !isBlack;
		}
		else
		{
			tiles[thisTile] = true;
		}
	}
	int blackCount = tiles.Values.Count(thisBool => thisBool);
	Console.WriteLine($"Part 1: {blackCount}");
}

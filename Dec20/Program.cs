using Dec20;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var tiles = new List<Tile>();
	var thisTileData = new List<string>();
	foreach(string thisLine in allLines)
	{
		if (thisLine.Length == 0)
		{
			tiles.Add(new Tile(thisTileData));
			thisTileData = new();
		}
		else
		{
			thisTileData.Add(thisLine);
		}
	}
	if (thisTileData.Count > 0)
	{
		tiles.Add(new Tile(thisTileData));
	}
	for (int i = 0; i < tiles.Count - 1; i++)
	{
		for (int j = i + 1; j < tiles.Count; j++)
		{
			if (i != j)
			{
				tiles[i].Connect(tiles[j]);
			}
		}
	}
	long product = 1L;
	foreach (Tile thisTile in tiles)
	{
		if (thisTile.GetNeighborCount() == 2)
		{
			product *= thisTile.GetID();
		}
	}
	Console.WriteLine($"Part 1: {product}");
}

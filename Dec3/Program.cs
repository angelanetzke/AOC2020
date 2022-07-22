using Dec3;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var grid = new TreeGrid(allLines);
	long treeCount = grid.CountTrees(3, 1);
	Console.WriteLine($"Part 1: {treeCount}");
}

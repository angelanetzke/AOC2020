using Dec23;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theGame = new Game(allLines[0]);
	theGame.Play(100);
	string labels = theGame.GetLabels();
	Console.WriteLine($"Part 1: {labels}");
}

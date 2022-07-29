using Dec22;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var theGame = new Game(allLines);
	int finalScore = theGame.GetFinalWinnerScore();
	Console.WriteLine($"Part 1: {finalScore}");
}

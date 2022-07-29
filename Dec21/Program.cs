using System.Text.RegularExpressions;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var counts = new Dictionary<string, int>();
	var allergens = new Dictionary<string, List<HashSet<string>>>();
	var safeIngredients = new HashSet<String>();
	foreach (string thisLine in allLines)
	{
		var ingredientArray = thisLine.Split(" (contains ")[0].Split(' ');
		foreach (string thisIngredient in ingredientArray)
		{
			safeIngredients.Add(thisIngredient);
			if (counts.TryGetValue(thisIngredient, out int count))
			{
				counts[thisIngredient] = count + 1;
			}
			else
			{
				counts[thisIngredient] = 1;
			}
		}
		var ingredientSet = new HashSet<string>(ingredientArray);
		var allergenMatches = new Regex(@"(\w+)").Matches(thisLine.Split(" (contains ")[1]);
		foreach (Match thisMatch in allergenMatches)
		{
			if (allergens.TryGetValue(thisMatch.Groups[0].Value, out List<HashSet<string>>? list))
			{
				list.Add(ingredientSet);
			}
			else
			{
				allergens[thisMatch.Groups[0].Value] = new List<HashSet<string>>() { ingredientSet };
			}
		}
	}
	foreach (string thisKey in allergens.Keys)
	{
		var thisList = allergens[thisKey];
		HashSet<string> combinedSet = thisList[0];
		for (int i = 0; i < thisList.Count; i++)
		{
			if (combinedSet == null)
			{
				combinedSet = thisList[i];
			}
			else
			{
				combinedSet = combinedSet.Intersect(thisList[i]).ToHashSet();
			}
		}
		foreach (string thisIngredient in combinedSet)
		{
			safeIngredients.Remove(thisIngredient);
		}
	}
	int totalCount = 0;
	foreach (string thisIngredient in safeIngredients)
	{
		totalCount += counts[thisIngredient];
	}
	Console.WriteLine($"Part 1: {totalCount}");
}



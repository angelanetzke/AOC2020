using System.Text.RegularExpressions;
using System.Text;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var rules = new Dictionary<string, string>();
	var inputStrings = new List<string>();
	foreach (var thisLine in allLines)
	{
		if (new Regex(@"^\d+:.+").IsMatch(thisLine))
		{
			string key = thisLine.Split(':')[0];
			string value = thisLine.Split(':')[1].Trim();
			rules[key] = value;
		}
		else if (thisLine.Length > 0)
		{
			inputStrings.Add(thisLine);
		}
	}
	var theRegex = new Regex(@"^" + GetRegex(rules, rules["0"]) + "$");
	int matchCount = inputStrings.Count(thisString => theRegex.IsMatch(thisString));
	Console.WriteLine($"Part 1: {matchCount}");
}

static string GetRegex(Dictionary<string, string> ruleSet, string rule)
{
	rule = rule.Trim();
	if (rule[0] == '"')
	{
		return rule[1].ToString();
	}
	else if (rule.Contains('|'))
	{
		var builder = new StringBuilder();
		var components = rule.Split('|');
		for (int i = 0; i < components.Length; i++)
		{
			builder.Append('(');
			builder.Append(GetRegex(ruleSet, components[i]));
			builder.Append(')');
			if (i < components.Length - 1)
			{
				builder.Append('|');
			}
		}
		return builder.ToString();
	}
	else if (rule.Contains(' '))
	{
		var builder = new StringBuilder();
		var components = rule.Split(' ');
		for (int i = 0; i < components.Length; i++)
		{
			builder.Append('(');
			builder.Append(GetRegex(ruleSet, components[i]));
			builder.Append(')');
		}
		return builder.ToString();
	}
	else
	{
		return GetRegex(ruleSet, ruleSet[rule]);
	}
}


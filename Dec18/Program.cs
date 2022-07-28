using System.Text.RegularExpressions;

var allLines = System.IO.File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	long sum = 0;
	foreach (string thisLine in allLines)
	{
		sum += Evaluate(thisLine);
	}
	Console.WriteLine($"Part 1: {sum}");
}

static long Evaluate(string expression)
{
	if ((new Regex(@"^\d+$")).IsMatch(expression))
	{
		return long.Parse(expression);
	}
	List<string> components = new();
	string[]? nextComponent = GetNextComponent(expression, 0);
	while (nextComponent != null)
	{
		components.Add(nextComponent[0]);
		nextComponent = GetNextComponent(expression, int.Parse(nextComponent[1]));
	}
	long value = 0;
	int i = 0;
	while (i < components.Count)
	{
		if (i == 0)
		{
			value = Evaluate(components[i]);
			i++;
		}
		else
		{
			if (components[i] == "+")
			{
				i++;
				value += Evaluate(components[i]);
				i++;
			}
			else if (components[i] == "*")
			{
				i++;
				value *= Evaluate(components[i]);
				i++;
			}
		}
	}
	return value;
}

static string[]? GetNextComponent(string expression, int startIndex)
{
	if (startIndex >= expression.Length)
	{
		return null;
	}
	if (expression[startIndex] == ' ')
	{
		startIndex++;
	}
	int openParens = 0;
	if (expression[startIndex] == '(')
	{
		openParens = 1;
	}
	if (openParens == 0)
	{
		if (expression[startIndex] == '+' || expression[startIndex] == '*')
		{
			return new string[] { expression[startIndex].ToString(), (startIndex + 1).ToString() };
		}
		else
		{
			string component = (new Regex(@"^(?<number>\d+)")).Match(expression[startIndex..]).Groups["number"].Value;
			return new string[] { component, (startIndex + component.Length).ToString() };
		}
	}
	else
	{
		int endIndex = startIndex;
		while (openParens > 0)
		{
			endIndex++;
			if (expression[endIndex] == '(')
			{
				openParens++;
			}
			if (expression[endIndex] == ')')
			{
				openParens--;
			}
		}
		//remove outer matching parentheses
		return new string[] { expression.Substring(startIndex + 1, endIndex - startIndex - 1), (endIndex + 1).ToString() };
	}
}

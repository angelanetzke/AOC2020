using System.Text.RegularExpressions;

namespace Dec16
{
	internal class Ticket
	{
		int[] fieldValues;
		List<string> rules;

		public Ticket(string ticketData, List<string> rules)
		{
			fieldValues = Array.ConvertAll(ticketData.Split(','), x => int.Parse(x));
			this.rules = rules;
		}

		public int GetErrorRate()
		{
			int errorRate = 0;
			foreach (int thisFieldValue in fieldValues)
			{
				bool isValid = false;
				foreach (string thisRule in rules)
				{
					if (Validate(thisFieldValue, thisRule))
					{
						isValid = true;
						break;
					}
				}
				if (!isValid)
				{
					errorRate += thisFieldValue;
				}
			}
			return errorRate;
		}

		private static bool Validate(int value, string rule)
		{
			//departure location: 41-525 or 538-968
			var ruleRegex = new Regex(@"^[a-z ]+: (?<min1>\d+)-(?<max1>\d+) or (?<min2>\d+)-(?<max2>\d+)$");
			int min1 = int.Parse(ruleRegex.Match(rule).Groups["min1"].Value);
			int max1 = int.Parse(ruleRegex.Match(rule).Groups["max1"].Value);
			int min2 = int.Parse(ruleRegex.Match(rule).Groups["min2"].Value);
			int max2 = int.Parse(ruleRegex.Match(rule).Groups["max2"].Value);
			return (min1 <= value && value <= max1) || (min2 <= value && value <= max2);

		}


	}
}

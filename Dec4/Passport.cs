namespace Dec4
{
	internal class Passport
	{
		private readonly Dictionary<string, string> fields = new();
		private static readonly string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

		public void AddFields(string nextLine)
		{
			var entries = nextLine.Split(" ");
			foreach (string thisEntry in entries)
			{
				var components = thisEntry.Split(":");
				fields.Add(components[0], components[1]);
			}
		}

		public bool IsEmpty()
		{
			return fields.Count == 0;
		}

		public bool IsValid()
		{
			foreach (string thisRequiredField in requiredFields)
			{
				if (!fields.ContainsKey(thisRequiredField))
				{
					return false;
				}
			}
			return true;
		}
	}
}

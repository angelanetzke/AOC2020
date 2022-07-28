using System.Text.RegularExpressions;

namespace Dec20
{
	internal class Tile
	{
		private static readonly int SIZE = 10;
		private readonly string[] data = new string[SIZE];
		private readonly string[] borders = new string[4];
		private readonly int id;
		private readonly HashSet<Tile> neighbors = new();

		public Tile(List<string> inputLines)
		{
			id = int.Parse(new Regex(@"Tile (?<id>\d+):").Match(inputLines[0]).Groups["id"].Value);
			for (int i = 1; i < inputLines.Count; i++)
			{
				data[i - 1] = inputLines[i];
				if (i == 1)
				{
					borders[0] = inputLines[i];
				}
				else if (i == inputLines.Count - 1)
				{
					borders[1] = inputLines[i];
				}
				borders[2] += inputLines[i][0];
				borders[3] += inputLines[i][inputLines[i].Length - 1];
			}
		}

		public int GetID()
		{
			return id;
		}

		public int GetNeighborCount()
		{
			return neighbors.Count;
		}

		public void Connect(Tile other)
		{
			for (int i = 0; i < borders.Length; i++)
			{
				for (int j = 0; j < borders.Length; j++)
				{
					if (borders[i] == other.borders[j])
					{
						neighbors.Add(other);
						other.neighbors.Add(this);
						return;
					}
					if (borders[i] == new string(other.borders[j].Reverse().ToArray()))
					{
						neighbors.Add(other);
						other.neighbors.Add(this);
						return;
					}
				}
			}
		}








	}
}

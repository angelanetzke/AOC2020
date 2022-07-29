namespace Dec24
{
	internal class Tile
	{
		private readonly int x;
		private readonly int y;

		public Tile(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is Tile other)
			{
				return x == other.x && y == other.y;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return (x + y).GetHashCode();
		}

	}
}

using System.Text.RegularExpressions;

namespace Dec22
{
	internal class Game
	{
		private readonly List<int> player1Start = new();
		private readonly List<int> player2Start = new();
		public Game(string[] allLines)
		{
			bool isPlayer1Filling = true;
			foreach(string thisLine in allLines)
			{
				if (thisLine.Length == 0)
				{
					isPlayer1Filling = false;
				}
				else if (new Regex(@"^\d+$").IsMatch(thisLine))
				{
					if (isPlayer1Filling)
					{
						player1Start.Add(int.Parse(thisLine));
					}
					else
					{
						player2Start.Add(int.Parse(thisLine));
					}
				}
			}
		}

		public int GetFinalWinnerScore()
		{
			var player1 = new List<int>(player1Start);
			var player2 = new List<int>(player2Start);
			while (player1.Count > 0 && player2.Count > 0)
			{
				int player1Card = player1[0];
				player1.RemoveAt(0);
				int player2Card = player2[0];
				player2.RemoveAt(0);
				if (player1Card > player2Card)
				{
					player1.Add(player1Card);
					player1.Add(player2Card);
				}
				else
				{
					player2.Add(player2Card);
					player2.Add(player1Card);
				}
			}			
			if (player1.Count > player2.Count)
			{
				return CalculateScore(player1);
			}
			else
			{
				return CalculateScore(player2);
			}
		}

		private static int CalculateScore(List<int> hand)
		{
			int score = 0;
			for (int i = 0; i < hand.Count; i++)
			{
				score += (hand.Count - i) * hand[i];
			}
			return score;
		}


	}
}

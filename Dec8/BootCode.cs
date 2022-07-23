namespace Dec8
{
	internal class BootCode
	{
		private readonly string[] instructions;
		private int ip = 0;
		private int acc = 0;
		private readonly bool[] hasBeenExecuted;

		public BootCode(string[] instructions)
		{
			this.instructions = instructions;
			hasBeenExecuted = new bool[instructions.Length];
		}

		public int GetLastAcc()
		{
			Execute();
			return acc;
		}

		public void Execute()
		{
			if (ip >= instructions.Length)
			{
				return;
			}
			else if (hasBeenExecuted[ip])
			{
				return;
			}
			else
			{
				hasBeenExecuted[ip] = true;
				string opcode = instructions[ip].Split(' ')[0];
				int argument = int.Parse(instructions[ip].Split(' ')[1]);
				switch(opcode)
				{
					case "acc":
						acc += argument;
						ip++;
						break;
					case "jmp":
						ip += argument;
						break;
					case "nop":
						ip++;
						break;
				}
				Execute();
			}
		}


	}
}

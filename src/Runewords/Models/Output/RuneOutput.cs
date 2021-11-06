using Runewords.Interfaces;

namespace Runewords.Models.Output
{
	public record RuneOutput : IOutput
	{
		public string Name { get; }
		public byte Level { get; }

		public RuneOutput(string name,
			byte level)
		{
			Name = name;
			Level = level;
		}
	}
}

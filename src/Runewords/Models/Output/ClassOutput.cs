using Runewords.Interfaces;

namespace Runewords.Models.Output
{
	public record ClassOutput : IOutput
	{
		public string Name { get; }
		public string Description { get; }

		public ClassOutput(string name,
			string description)
		{
			Name = name;
			Description = description;
		}
	}
}

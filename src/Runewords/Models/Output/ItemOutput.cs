using Runewords.Interfaces;

namespace Runewords.Models.Output
{
	public record ItemOutput : IOutput
	{
		public string Name { get; }
		public string Description { get; }

		public ItemOutput(string name,
			string description)
		{
			Name = name;
			Description = description;
		}
	}
}

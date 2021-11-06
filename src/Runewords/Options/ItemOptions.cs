using Runewords.Interfaces;

namespace Runewords.Options
{
	public record ItemOptions : IOptions
	{
		public string? Item { get; set; }
	}
}

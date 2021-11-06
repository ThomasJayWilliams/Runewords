using Runewords.Interfaces;

namespace Runewords.Options
{
	public record RunesOptions : IOptions
	{
		public byte Level { get; set; }
		public string? Rune { get; set; }
	}
}

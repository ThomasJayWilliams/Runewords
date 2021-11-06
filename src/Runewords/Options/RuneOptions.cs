using Runewords.Interfaces;

namespace Runewords.Options
{
	public record RuneOptions : IOptions
	{
		public byte Level { get; set; }
		public string? Rune { get; set; }
	}
}

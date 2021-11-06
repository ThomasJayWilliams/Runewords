namespace Runewords.Models
{
	public record Rune
	{
		public string Name { get; set; } = null!;
		public byte Level { get; set; }
	}
}

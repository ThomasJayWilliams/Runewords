namespace Runewords.Models
{
	public class RunewordRune
	{
		public ushort Id { get; set; }
		public byte RuneId { get; set; }
		public ushort RunewordId { get; set; }
		public byte Position { get; set; }

		public Rune Rune { get; set; } = null!;
		public Runeword Runeword { get; set; } = null!;
	}
}

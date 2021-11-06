namespace Runewords.Models
{
	public class RunewordItem
	{
		public byte ItemId { get; set; }
		public ushort RunewordId { get; set; }

		public Item Item { get; set; } = null!;
		public Runeword Runeword { get; set; } = null!;
	}
}

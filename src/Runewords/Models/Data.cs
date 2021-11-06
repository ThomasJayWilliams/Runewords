using System.Collections.Generic;

namespace Runewords.Models
{
	public record Data
	{
		public IReadOnlyCollection<Class> Classes { get; set; } = null!;
		public IReadOnlyCollection<Rune> Runes { get; set; } = null!;
		public IReadOnlyCollection<Runeword> Runewords { get; set; } = null!;
		public IReadOnlyCollection<Item> Items { get; set; } = null!;
	}
}

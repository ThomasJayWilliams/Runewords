using System.Collections.Generic;

namespace Runewords.Models
{
	public record Rune
	{
		public byte Id { get; set; }
		public string Name { get; set; } = null!;
		public byte Level { get; set; }
		public virtual ICollection<RunewordRune> RunewordRunes { get; set; } = new List<RunewordRune>();
	}
}

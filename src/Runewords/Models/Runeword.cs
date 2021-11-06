using System.Collections.Generic;

namespace Runewords.Models
{
	public record Runeword
	{
		public string Class { get; set; } = null!;
		public IReadOnlyCollection<Rune> Runes { get; set; } = null!;
		public IReadOnlyCollection<string> Items { get; set; } = null!;
		public bool HasCharges { get; set; }
		public bool SkillBonus { get; set; }
	}
}

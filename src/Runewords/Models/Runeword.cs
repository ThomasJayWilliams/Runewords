using System.Collections.Generic;

namespace Runewords.Models
{
	public record Runeword
	{
		public ushort Id { get; set; }
		public byte ClassId { get; set; }
		public byte Level { get; set; }
		public bool HasCharges { get; set; }
		public bool SkillBonus { get; set; }
		public virtual ICollection<RunewordItem> RunewordItems { get; set; } = new List<RunewordItem>();
		public virtual ICollection<RunewordRune> RunewordRunes { get; set; } = new List<RunewordRune>();
		public virtual Class Class { get; set; } = null!;
	}
}

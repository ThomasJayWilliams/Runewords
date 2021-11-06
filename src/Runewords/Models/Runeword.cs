using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Runewords.Models
{
	public record Runeword
	{
		public string Class { get; set; } = null!;
		public byte Level { get; set; }
		public IReadOnlyCollection<string> Runes  { get; set; } = null!;
		[JsonIgnore]
		[Newtonsoft.Json.JsonIgnore]
		public IReadOnlyCollection<Rune> DataRunes { get; set; } = null!;
		public IReadOnlyCollection<string> Items { get; set; } = null!;
		public bool HasCharges { get; set; }
		public bool SkillBonus { get; set; }
	}
}

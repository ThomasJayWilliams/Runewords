using Runewords.Enums;
using Runewords.Interfaces;

namespace Runewords.Options
{
	public record RunewordsOptions : IOptions
	{
		public byte Level { get; set; }
		public string? Class { get; set; }
		public Ordering Order { get; set; }
		public bool DescOrder { get; set; }
		public string? Item { get; set; }
		public string? Rune { get; set; }
		public byte Sockets { get; set; }
		public byte MinLevel { get; set; }
		public byte MaxLevel { get; set; }
		public bool SkillBonus { get; set; }
		public bool NoSkillBonus { get; set; }
		public bool Charges { get; set; }
		public bool NoCharges { get; set; }
	}
}

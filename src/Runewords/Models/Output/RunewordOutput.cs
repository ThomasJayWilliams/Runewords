using Runewords.Interfaces;
using System.Collections.Generic;

namespace Runewords.Models.Output
{
	public record RunewordOutput : IOutput
	{
		public string Class { get; }
		public byte Level { get; set; }
		public IEnumerable<RuneOutput> Runes { get; }
		public IEnumerable<ItemOutput> Items { get; }
		public bool HasCharges { get; }
		public bool SkillBonus { get; }

		public RunewordOutput(string @class,
			IEnumerable<RuneOutput> runes, byte level,
			IEnumerable<ItemOutput> items, bool hasChrges,
			bool skillBonus)
		{
			Level = level;
			Class = @class;
			Runes = runes;
			Items = items;
			HasCharges = hasChrges;
			SkillBonus = skillBonus;
		}
	}
}

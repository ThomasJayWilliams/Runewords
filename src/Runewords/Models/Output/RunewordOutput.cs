using Runewords.Interfaces;
using System.Collections.Generic;

namespace Runewords.Models.Output
{
	public record RunewordOutput : IOutput
	{
		public string Class { get; }
		public byte Level { get; }
		public IEnumerable<RuneOutput> Runes { get; }
		public IEnumerable<string> Items { get; }
		public bool HasCharges { get; }
		public bool SkillBonus { get; }

		public RunewordOutput(string @class,
			byte level, IEnumerable<RuneOutput> runes,
			IEnumerable<string> items, bool hasChrges,
			bool skillBonus)
		{
			Class = @class;
			Level = level;
			Runes = runes;
			Items = items;
			HasCharges = hasChrges;
			SkillBonus = skillBonus;
		}
	}
}

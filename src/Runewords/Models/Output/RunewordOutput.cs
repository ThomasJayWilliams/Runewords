using Runewords.Interfaces;
using System.Collections.Generic;

namespace Runewords.Models.Output
{
	public record RunewordOutput : IOutput
	{
		public string Class { get; }
		public IEnumerable<RuneOutput> Runes { get; }
		public IEnumerable<string> Items { get; }
		public bool HasCharges { get; }
		public bool SkillBonus { get; }

		public RunewordOutput(string @class,
			IEnumerable<RuneOutput> runes,
			IEnumerable<string> items, bool hasChrges,
			bool skillBonus)
		{
			Class = @class;
			Runes = runes;
			Items = items;
			HasCharges = hasChrges;
			SkillBonus = skillBonus;
		}
	}
}

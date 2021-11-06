using AutoMapper;
using Runewords.Models;
using Runewords.Models.Output;
using System.Linq;

namespace Runewords.Maps
{
	public class RunewordOutputProfile : Profile
	{
		public RunewordOutputProfile()
		{
			CreateMap<Runeword, RunewordOutput>()
				.ConvertUsing(s => new RunewordOutput(s.Class.Name,
					s.RunewordRunes.OrderBy(r => r.Position).Select(r => new RuneOutput(r.Rune.Name, r.Rune.Level)), s.Level,
					s.RunewordItems.Select(i => new ItemOutput(i.Item.Name, i.Item.Description)), s.HasCharges, s.SkillBonus));
		}
	}
}

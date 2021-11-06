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
				.ConvertUsing(s => new RunewordOutput(s.Class, s.Level,
					s.DataRunes.Select(r => new RuneOutput(r.Name, r.Level)),
					s.Items, s.HasCharges, s.SkillBonus));
		}
	}
}

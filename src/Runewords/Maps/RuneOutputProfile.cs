using AutoMapper;
using Runewords.Models;
using Runewords.Models.Output;

namespace Runewords.Maps
{
	public class RuneOutputProfile : Profile
	{
		public RuneOutputProfile()
		{
			CreateMap<Rune, RuneOutput>()
				.ConvertUsing(s => new RuneOutput(s.Name, s.Level));
		}
	}
}

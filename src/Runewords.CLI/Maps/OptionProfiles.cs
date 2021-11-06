using AutoMapper;
using Runewords.Options;

namespace Runewords.CLI.Maps
{
	public class RuneOptionsProfile : Profile
	{
		public RuneOptionsProfile()
		{
			CreateMap<RuneVerb, RuneOptions>();
		}
	}

	public class RunewordOptionsProfile : Profile
	{
		public RunewordOptionsProfile()
		{
			CreateMap<RunewordVerb, RunewordOptions>();
		}
	}

	public class ItemOptionsProfile : Profile
	{
		public ItemOptionsProfile()
		{
			CreateMap<ItemVerb, ItemOptions>();
		}
	}

	public class ClassOptionsProfile : Profile
	{
		public ClassOptionsProfile()
		{
			CreateMap<ClassVerb, ClassOptions>();
		}
	}
}

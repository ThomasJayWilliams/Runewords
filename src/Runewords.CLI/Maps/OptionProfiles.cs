using AutoMapper;
using Runewords.Options;

namespace Runewords.CLI.Maps
{
	public class RunesOptionsProfile : Profile
	{
		public RunesOptionsProfile()
		{
			CreateMap<RunesVerb, RunesOptions>();
		}
	}

	public class RunewordsOptionsProfile : Profile
	{
		public RunewordsOptionsProfile()
		{
			CreateMap<RunewordsVerb, RunewordsOptions>();
		}
	}

	public class ShortcutsOptionsProfile : Profile
	{
		public ShortcutsOptionsProfile()
		{
			CreateMap<ShortcutsVerb, ShortcutsOptions>();
		}
	}

	public class ClassesOptionsProfile : Profile
	{
		public ClassesOptionsProfile()
		{
			CreateMap<ClassesVerb, ClassesOptions>();
		}
	}
}

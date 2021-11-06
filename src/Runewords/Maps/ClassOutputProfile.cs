using AutoMapper;
using Runewords.Models;
using Runewords.Models.Output;

namespace Runewords.Maps
{
	public class ClassOutputProfile : Profile
	{
		public ClassOutputProfile()
		{
			CreateMap<Class, ClassOutput>()
				.ConstructUsing(s => new ClassOutput(s.Name, s.Description));
		}
	}
}

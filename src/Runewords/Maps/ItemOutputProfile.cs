using AutoMapper;
using Runewords.Models;
using Runewords.Models.Output;

namespace Runewords.Maps
{
	public class ItemOutputProfile : Profile
	{
		public ItemOutputProfile()
		{
			CreateMap<Item, ItemOutput>()
				.ConvertUsing(s => new ItemOutput(s.Name, s.Description));
		}
	}
}

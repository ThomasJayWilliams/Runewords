using AutoMapper;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Repositories
{
	public sealed class ItemRepository : IItemRepository
	{
		private readonly IDataReader _dataReader;
		private readonly IMapper _mapper;

		public ItemRepository(IDataReader dataReader,
			IMapper mapper)
		{
			_mapper = mapper;
			_dataReader = dataReader;
		}

		public IEnumerable<ItemOutput> Get(ItemOptions options)
		{
			var data = _dataReader.GetData();

			return data.Items
				.Where(s => string.IsNullOrWhiteSpace(options.Item) || s.Name.Contains(options.Item.ToLower()))
				.Select(s => _mapper.Map<ItemOutput>(s));
		}
	}
}

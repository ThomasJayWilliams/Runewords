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
		private readonly RunewordsDbContext _dbContext;
		private readonly IMapper _mapper;

		public ItemRepository(RunewordsDbContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<ItemOutput> Get(ItemOptions options)
		{
			return _dbContext.Items
				.Where(s => string.IsNullOrWhiteSpace(options.Item) || s.Name.Contains(options.Item.ToLower()))
				.Select(s => _mapper.Map<ItemOutput>(s));
		}
	}
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Repositories
{
	public sealed class RuneRepository : IRuneRepository
	{
		private readonly RunewordsDbContext _dbContext;
		private readonly IMapper _mapper;

		public RuneRepository(RunewordsDbContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<RuneOutput> Get(RuneOptions options)
		{
			var filtered = _dbContext.Runes
				.Where(r => (options.Level <= 0 || options.Level == r.Level)
					&& (string.IsNullOrWhiteSpace(options.Rune) || r.Name.ToLower() == options.Rune.ToLower()))
				.OrderBy(r => r.Level);
			return filtered.ProjectTo<RuneOutput>(_mapper.ConfigurationProvider);
		}
	}
}

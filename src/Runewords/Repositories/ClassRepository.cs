using AutoMapper;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Repositories
{
	public sealed class ClassRepository : IClassRepository
	{
		private readonly RunewordsDbContext _dbContext;
		private readonly IMapper _mapper;

		public ClassRepository(RunewordsDbContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<ClassOutput> Get(ClassOptions options)
		{
			return _dbContext.Classes
				.Select(c => _mapper.Map<ClassOutput>(c));
		}
	}
}

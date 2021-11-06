using AutoMapper;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Repositories
{
	public sealed class RuneRepository : IRuneRepository
	{
		private readonly IDataReader _dataReader;
		private readonly IMapper _mapper;

		public RuneRepository(IDataReader dataReader,
			IMapper mapper)
		{
			_mapper = mapper;
			_dataReader = dataReader;
		}

		public IEnumerable<RuneOutput> Get(RuneOptions options)
		{
			var data = _dataReader.GetData();

			return data.Runes
				.Where(r => (options.Level <= 0 || options.Level == r.Level) &&
					(string.IsNullOrWhiteSpace(options.Rune) || r.Name.ToLower() == options.Rune.ToLower()))
				.Select(r => _mapper.Map<RuneOutput>(r))
				.OrderBy(r => r.Level);
		}
	}
}

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
		private readonly IDataReader _dataReader;
		private readonly IMapper _mapper;

		public ClassRepository(IDataReader dataReader,
			IMapper mapper)
		{
			_dataReader = dataReader;
			_mapper = mapper;
		}

		public IEnumerable<ClassOutput> Get(ClassOptions options)
		{
			return _dataReader
				.GetData().Classes
				.Select(c => _mapper.Map<ClassOutput>(c));
		}
	}
}

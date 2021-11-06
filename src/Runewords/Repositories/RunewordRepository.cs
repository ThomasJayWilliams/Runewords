using AutoMapper;
using Runewords.Enums;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Repositories
{
	public sealed class RunewordRepository : IRunewordRepository
	{
		private readonly IDataReader _dataReader;
		private readonly IMapper _mapper;

		public RunewordRepository(IDataReader dataReader,
			IMapper mapper)
		{
			_mapper = mapper;
			_dataReader = dataReader;
		}

		public IEnumerable<RunewordOutput> Get(RunewordOptions options)
		{
			var data = _dataReader.GetData();
			var filtered = data.Runewords
				.Where(word => (options.Level <= 0 || options.Level == word.Runes.Max(r => r.Level))
					&& (string.IsNullOrWhiteSpace(options.Class) || options.Class.ToLower() == word.Class.ToLower())
					&& (string.IsNullOrWhiteSpace(options.Item) || word.Items.Contains(options.Item.ToLower()))
					&& (string.IsNullOrWhiteSpace(options.Rune) || word.Runes.Any(r => r.Name.ToLower() == options.Rune.ToLower()))
					&& (options.Sockets <= 0 || word.Runes.Count == options.Sockets)
					&& (options.MinLevel <= 0 || options.Level > 0 || word.Runes.Max(r => r.Level) >= options.MinLevel)
					&& (options.MaxLevel <= 0 || options.Level > 0 || word.Runes.Max(r => r.Level) <= options.MaxLevel)
					&& (!options.Charges || word.HasCharges)
					&& (!options.NoCharges || !word.HasCharges)
					&& (!options.SkillBonus || word.SkillBonus)
					&& (!options.NoSkillBonus || !word.SkillBonus));
			var mapped = filtered.Select(word => _mapper.Map<RunewordOutput>(word));
			var orderFunc = GetOrderFunc(options.Order);

			return options.DescOrder
				? mapped.OrderByDescending(orderFunc)
				: mapped.OrderBy(orderFunc);
		}

		private static Func<RunewordOutput, object> GetOrderFunc(Ordering ordering)
		{
			return ordering switch
			{
				Ordering.@class => w => w.Class,
				_ => w => w.Runes.Max(r => r.Level),
			};
		}
	}
}

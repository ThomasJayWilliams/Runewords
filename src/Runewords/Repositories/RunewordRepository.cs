using AutoMapper;
using Runewords.Enums;
using Runewords.Interfaces;
using Runewords.Models;
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

			foreach (var word in data.Runewords)
			{
				word.DataRunes = word.Runes
					.Select(r => data.Runes.First(rune => rune.Name == r))
					.ToList();
				word.Level = word.DataRunes
					.Max(r => r.Level);
			}

			var filtered = data.Runewords
				.Where(word => (options.Level <= 0 || options.Level == word.Level)
					&& (string.IsNullOrWhiteSpace(options.Class) || options.Class.ToLower() == word.Class.ToLower())
					&& (string.IsNullOrWhiteSpace(options.Item) || word.Items.Contains(options.Item.ToLower()))
					&& (string.IsNullOrWhiteSpace(options.Rune) || word.Runes.Any(r => r.ToLower() == options.Rune.ToLower()))
					&& (options.Sockets <= 0 || word.Runes.Count == options.Sockets)
					&& (options.MinLevel <= 0 || options.Level > 0 || word.Level >= options.MinLevel)
					&& (options.MaxLevel <= 0 || options.Level > 0 || word.Level <= options.MaxLevel)
					&& (!options.Charges || word.HasCharges)
					&& (!options.NoCharges || !word.HasCharges)
					&& (!options.SkillBonus || word.SkillBonus)
					&& (!options.NoSkillBonus || !word.SkillBonus))
				.Select(word => _mapper.Map<RunewordOutput>(word));
			var orderFunc = GetOrderFunc(options.Order);

			return options.DescOrder
				? filtered.OrderByDescending(orderFunc)
				: filtered.OrderBy(orderFunc);
		}

		private static Func<RunewordOutput, object> GetOrderFunc(Ordering ordering)
		{
			return ordering switch
			{
				Ordering.@class => w => w.Class,
				_ => w => w.Level,
			};
		}
	}
}

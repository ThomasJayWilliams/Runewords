using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
		private readonly RunewordsDbContext _dbContext;
		private readonly IMapper _mapper;

		public RunewordRepository(RunewordsDbContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<RunewordOutput> Get(RunewordOptions options)
		{
			var filtered = _dbContext.Runewords
				.Include(r => r.Class)
				.Include(r => r.RunewordItems)
					.ThenInclude(i => i.Item)
				.Include(r => r.RunewordRunes)
					.ThenInclude(r => r.Rune)
				.Where(word => (options.Level <= 0 || options.Level == word.Level)
					&& (string.IsNullOrWhiteSpace(options.Class) || options.Class.ToLower() == word.Class.Name.ToLower())
					&& (string.IsNullOrWhiteSpace(options.Item) || word.RunewordItems.Any(i => i.Item.Name.ToLower() == options.Item.ToLower()))
					&& (string.IsNullOrWhiteSpace(options.Rune) || word.RunewordRunes.Any(r => r.Rune.Name.ToLower() == options.Rune.ToLower()))
					&& (options.Sockets <= 0 || word.RunewordRunes.Count == options.Sockets)
					&& (options.MinLevel <= 0 || options.Level > 0 || word.Level >= options.MinLevel)
					&& (options.MaxLevel <= 0 || options.Level > 0 || word.Level <= options.MaxLevel)
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
				_ => w => w.Level,
			};
		}
	}
}

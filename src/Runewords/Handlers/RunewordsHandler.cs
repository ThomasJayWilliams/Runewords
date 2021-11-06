using Runewords.Interfaces;
using Runewords.Models;
using Runewords.Options;
using System.Linq;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class RunewordsHandler : IRunewordsHandler
	{
		private readonly IDataReader _dataReader;

		public RunewordsHandler(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		public void Handle(RunewordsOptions options)
		{
			var data = _dataReader.GetData();

			ParseRunes(data);

			WriteLine("\nRunewords:\n");
			WriteLine($"\t{Constants.ConsoleLineBreak}");
			Runeword.PrintHeaders();
			WriteLine($"\t{Constants.ConsoleLineBreak}");

			var orderFunc = Runeword.GetOrderFunc(options.Order);
			var ordered = options.DescOrder
				? data.Runewords.OrderByDescending(orderFunc)
				: data.Runewords.OrderBy(orderFunc);
			var totalCount = 0;

			foreach (var word in ordered)
			{
				if (options.Level > 0 && options.Level != word.Level
					|| !string.IsNullOrWhiteSpace(options.Class) && options.Class.ToLower() != word.Class.ToLower()
					|| !string.IsNullOrWhiteSpace(options.Item) && !word.Items.Contains(options.Item.ToLower())
					|| !string.IsNullOrWhiteSpace(options.Rune) && !word.Runes.Any(r => r.ToLower() == options.Rune.ToLower())
					|| options.Sockets > 0 && word.Runes.Count != options.Sockets
					|| options.MinLevel > 0 && options.Level == 0 && word.Level < options.MinLevel
					|| options.MaxLevel > 0 && options.Level == 0 && word.Level > options.MaxLevel
					|| options.Charges && !word.HasCharges
					|| options.NoCharges && word.HasCharges
					|| options.SkillBonus && !word.SkillBonus
					|| options.NoSkillBonus && word.SkillBonus)
				{
					continue;
				}

				word.Print();
				WriteLine($"\t{Constants.ConsoleLineBreak}");

				totalCount++;
			}

			WriteLine($"Total results count: {totalCount}");
		}

		private static void ParseRunes(Data data)
		{
			foreach (var word in data.Runewords)
			{
				word.DataRunes = data.Runes
					.Where(r => word.Runes.Contains(r.Name))
					.ToList();
				word.Level = word.DataRunes
					.Max(r => r.Level);
			}
		}
	}
}

using Newtonsoft.Json;
using Runewords.Interfaces;
using Runewords.Models;
using Runewords.Helpers;
using System.IO;
using System.Linq;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class RunewordsHandler : IHandler<RunewordsVerb>
	{
		public void Handle(RunewordsVerb options)
		{
			var filePath = Path.Combine(FileSystemHelper.AssemblyDirectory, Constants.DataFileName);
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(filePath))!;
			var runes = data.Runes.ToDictionary(k => k.Name, v => v.Level);

			WriteLine("\nRunewords:\n");
			WriteLine($"\t{Constants.ConsoleLineBreak}");
			Runeword.PrintHeaders();
			WriteLine($"\t{Constants.ConsoleLineBreak}");

			var orderFunc = Runeword.GetOrderFunc(options.Order);
			var ordered = options.DescOrder
				? data.Runewords.OrderByDescending(orderFunc)
				: data.Runewords.OrderBy(orderFunc);

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

				word.Print(runes);
				WriteLine($"\t{Constants.ConsoleLineBreak}");
			}
		}
	}
}

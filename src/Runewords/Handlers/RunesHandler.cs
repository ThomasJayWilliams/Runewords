using Newtonsoft.Json;
using Runewords.Interfaces;
using Runewords.Helpers;
using Runewords.Models;
using System.IO;
using System.Linq;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class RunesHandler : IHandler<RunesVerb>
	{
		public void Handle(RunesVerb options)
		{
			var filePath = Path.Combine(FileSystemHelper.AssemblyDirectory, Constants.DataFileName);
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(filePath))!;

			WriteLine("Runes:");
			WriteLine($"\t{Constants.ConsoleShortLineBreak}");

			foreach (var rune in data.Runes.OrderBy(r => r.Level))
			{
				if (options.Level > 0 && options.Level != rune.Level
					|| !string.IsNullOrWhiteSpace(options.Rune) && rune.Name.ToLower() != options.Rune.ToLower())
				{
					continue;
				}

				rune.Print();
				WriteLine($"\t{Constants.ConsoleShortLineBreak}");
			}
		}
	}
}

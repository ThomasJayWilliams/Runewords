using Newtonsoft.Json;
using Runewords.Interfaces;
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
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(Constants.DataFileName))!;

			WriteLine("Runes:");
			WriteLine(Constants.ConsoleLineBreak);

			foreach (var rune in data.Runes.OrderBy(r => r.Level))
			{
				if (options.Level > 0 && options.Level != rune.Level
					|| !string.IsNullOrWhiteSpace(options.Rune) && rune.Name.ToLower() != options.Rune.ToLower())
				{
					continue;
				}

				rune.Print();
				WriteLine(Constants.ConsoleLineBreak);
			}
		}
	}
}

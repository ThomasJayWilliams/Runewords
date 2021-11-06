using Runewords.Interfaces;
using System.Linq;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class RunesHandler : IRunesHandler
	{
		private readonly IDataReader _dataReader;

		public RunesHandler(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		public void Handle(RunesVerb options)
		{
			var data = _dataReader.GetData();

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

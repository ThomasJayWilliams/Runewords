using Runewords.Interfaces;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class ShortcutsHandler : IShortcutsHandler
	{
		private readonly IDataReader _dataReader;

		public ShortcutsHandler(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		public void Handle(ShortcutsVerb options)
		{
			var data = _dataReader.GetData();

			WriteLine("Shortcuts:");
			WriteLine($"\t{Constants.ConsoleShortLineBreak}");

			foreach (var shortcut in data.Shortcuts)
			{
				if (!string.IsNullOrWhiteSpace(options.Shortcut) && !shortcut.Name.Contains(options.Shortcut.ToLower()))
				{
					continue;
				}

				WriteLine($"\t{shortcut}");
			}
		}
	}
}

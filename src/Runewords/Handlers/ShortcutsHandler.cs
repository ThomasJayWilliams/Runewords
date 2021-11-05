using Newtonsoft.Json;
using Runewords.Helpers;
using Runewords.Interfaces;
using Runewords.Models;
using System.IO;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class ShortcutsHandler : IHandler<ShortcutsVerb>
	{
		public void Handle(ShortcutsVerb options)
		{
			var filePath = Path.Combine(FileSystemHelper.AssemblyDirectory, Constants.DataFileName);
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(filePath))!;

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

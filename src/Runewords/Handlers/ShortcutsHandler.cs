using Newtonsoft.Json;
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
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(Constants.DataFileName))!;

			WriteLine("Shortcuts:");
			WriteLine(Constants.ConsoleLineBreak);

			foreach (var shortcut in data.Shortcuts)
			{
				if (!string.IsNullOrWhiteSpace(options.Shortcut) && !shortcut.Name.Contains(options.Shortcut.ToLower()))
				{
					continue;
				}

				WriteLine(shortcut.ToString());
			}
		}
	}
}

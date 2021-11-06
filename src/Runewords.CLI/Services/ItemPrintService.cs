using Runewords.CLI.Interfaces;
using Runewords.Models.Output;
using System.Collections.Generic;
using static System.Console;

namespace Runewords.CLI.Services
{
	public class ItemPrintService : IItemPrintService
	{
		public void Print(IEnumerable<ItemOutput> output)
		{
			WriteLine("Items:");
			WriteLine($"\t{CLIConstants.ConsoleShortLineBreak}");

			foreach (var item in output)
			{
				WriteLine($"\t{item.Name} - {item.Description}.");
			}
		}
	}
}

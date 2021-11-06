using Runewords.CLI.Interfaces;
using Runewords.Models.Output;
using System.Collections.Generic;
using static System.Console;

namespace Runewords.CLI.Services
{
	public class ClassPrintService : IClassPrintService
	{
		public void Print(IEnumerable<ClassOutput> output)
		{
			WriteLine("Classes:");
			WriteLine($"\t{CLIConstants.ConsoleShortLineBreak}");

			foreach (var @class in output)
			{
				WriteLine($"\t{@class.Name} - {@class.Description}");
			}
		}
	}
}

using Runewords.CLI.Interfaces;
using Runewords.Models.Output;
using System;
using System.Collections.Generic;
using static System.Console;

namespace Runewords.CLI.Services
{
	public class RunePrintService : IRunePrintService
	{
		public void Print(IEnumerable<RuneOutput> output)
		{
			WriteLine("Runes:");
			WriteLine($"\t{CLIConstants.ConsoleShortLineBreak}");

			foreach (var rune in output)
			{
				ForegroundColor = ConsoleColor.DarkCyan;

				Write($"\t{rune.Name}");
				ResetColor();
				Write("(");

				ForegroundColor = ConsoleColor.DarkGreen;

				Write(rune.Level);
				ResetColor();
				WriteLine(")");
				WriteLine($"\t{CLIConstants.ConsoleShortLineBreak}");
			}
		}
	}
}

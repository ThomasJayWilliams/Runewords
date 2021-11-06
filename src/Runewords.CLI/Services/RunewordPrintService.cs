using Runewords.CLI.Interfaces;
using Runewords.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Runewords.CLI.Services
{
	public class RunewordPrintService : IRunewordPrintService
	{
		public void Print(IEnumerable<RunewordOutput> output)
		{
			WriteLine("\nRunewords:");
			WriteLine($"\t{CLIConstants.ConsoleLineBreak}");
			ResetColor();
			Write($"\tItems");
			Write("Level".PadLeft(37));
			Write("Class".PadLeft(14));
			Write("Charges".PadLeft(12));
			Write("Skill Bonus".PadLeft(17));
			WriteLine("Runes".PadLeft(10));
			WriteLine($"\t{CLIConstants.ConsoleLineBreak}");

			var data = output.ToList();

			foreach (var word in data)
			{
				var items = string.Join(',', word.Items);

				Write("\t");
				ForegroundColor = ConsoleColor.DarkYellow;
				Write(items);
				ForegroundColor = ConsoleColor.DarkGreen;
				Write(word.Level.ToString().PadLeft(40 - items.Length));
				ForegroundColor = ConsoleColor.DarkCyan;
				Write(word.Class.ToString().PadLeft(15));

				if (word.HasCharges)
				{
					ForegroundColor = ConsoleColor.DarkRed;
					Write("Has Charges".PadLeft(15));
				}

				else
				{
					Write("           ".PadLeft(15));
				}

				if (word.SkillBonus)
				{
					ForegroundColor = ConsoleColor.DarkCyan;
					Write("Skill Bonus".PadLeft(15));
				}

				else
				{
					Write("           ".PadLeft(15));
				}

				Write("".PadLeft(5));

				var runes = word.Runes.ToArray();

				for (int i = 0; i < runes.Length; i++)
				{
					var rune = runes[i];
					var level = word.Runes
						.FirstOrDefault(r => r.Name == rune.Name)!
						.Level;

					if (Constants.GemJewelRune == rune.Name)
					{
						ForegroundColor = ConsoleColor.DarkRed;
					}
					else if (Constants.JewelRune == rune.Name)
					{
						ForegroundColor = ConsoleColor.Green;
					}
					else
					{
						ResetColor();
					}

					Write($"{rune.Name}");
					ResetColor();
					Write("(");
					ForegroundColor = ConsoleColor.DarkGreen;
					Write(level);
					ResetColor();

					if (i + 1 < runes.Length)
					{
						Write(")");
						Write("-");
					}

					else
					{
						WriteLine(")");
					}
				}

				ResetColor();
				WriteLine($"\t{CLIConstants.ConsoleLineBreak}");
			}

			WriteLine($"Total results count: {data.Count}");
		}
	}
}

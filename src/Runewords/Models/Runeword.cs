using Runewords.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Runewords.Models
{
	public record Runeword
	{
		public string Class { get; set; } = null!;
		public byte Level { get; set; }
		public ICollection<string> Runes { get; set; } = null!;
		public ICollection<string> Items { get; set; } = null!;
		public bool HasCharges { get; set; }
		public bool SkillBonus { get; set; }

		public static void PrintHeaders()
		{
			Console.ResetColor();
			Console.Write($"\tItems");
			Console.Write("Level".PadLeft(37));
			Console.Write("Class".PadLeft(14));
			Console.Write("Charges".PadLeft(12));
			Console.Write("Skill Bonus".PadLeft(17));
			Console.WriteLine("Runes".PadLeft(10));
		}

		public void Print(IReadOnlyDictionary<string, byte> runeLevels)
		{
			var items = string.Join(',', Items);

			Console.Write("\t");
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write(items);
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write(Level.ToString().PadLeft(40 - items.Length));
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(Class.ToString().PadLeft(15));

			if (HasCharges)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("Has Charges".PadLeft(15));
			}

			else
			{
				Console.Write("           ".PadLeft(15));
			}

			if (SkillBonus)
			{
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("Skill Bonus".PadLeft(15));
			}

			else
			{
				Console.Write("           ".PadLeft(15));
			}

			PrintRunes(Runes.ToArray(), runeLevels);

			Console.ResetColor();
		}

		public static Func<Runeword, object> GetOrderFunc(Ordering ordering)
		{
			return ordering switch
			{
				Ordering.Class => w => w.Class,
				_ => w => w.Level,
			};
		}

		private static void PrintRunes(string[] runes,
			IReadOnlyDictionary<string, byte> runeLevels)
		{
			Console.Write("".PadLeft(5));

			for (int i = 0; i < runes.Length; i++)
			{
				var rune = runes[i];
				var level = runeLevels[rune];

				if (Constants.GemJewelRune == rune)
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
				}
				else if (Constants.JewelRune == rune)
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ResetColor();
				}
				Console.Write($"{rune}");
				Console.ResetColor();
				Console.Write("(");
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write(level);
				Console.ResetColor();

				if (i + 1 < runes.Length)
				{
					Console.Write(")");
					Console.Write("-");
				}

				else
				{
					Console.WriteLine(")");
				}
			}
		}
	}
}

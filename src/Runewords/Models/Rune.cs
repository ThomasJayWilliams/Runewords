using System;

namespace Runewords.Models
{
	public record Rune
	{
		public string Name { get; set; } = null!;
		public byte Level { get; set; }

		public void Print()
		{
			var defaultForeground = Console.ForegroundColor;

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(Name);
			Console.ForegroundColor = defaultForeground;
			Console.Write("(");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write(Level);
			Console.ForegroundColor = defaultForeground;
			Console.WriteLine(")");
		}
	}
}

using Runewords.Helpers;
using System.IO;

namespace Runewords
{
	public static class Constants
	{
		public const string GemJewelRune = "gmj";
		public const string JewelRune = "jwl";
		public static string SQLiteConnectionString => $"DataSource = {Path.Combine(FileSystemHelper.AssemblyDirectory, "runewords.db")}";
	}
}

using CommandLine;
using Runewords.Enums;
using Runewords.Interfaces;

namespace Runewords
{
	[Verb("runes", HelpText = "Displays existing runes.")]
	public record RunesVerb : IVerb
	{
		[Option('l', "lvl")]
		public byte Level { get; set; }
		[Option('r', "rune")]
		public string? Rune { get; set; }
	}

	[Verb("words", HelpText = "Displays existing runewords.")]
	public record RunewordsVerb : IVerb
	{
		[Option('l', "lvl")]
		public byte Level { get; set; }
		[Option('c', "class")]
		public string? Class { get; set; }
		[Option('o', "order")]
		public Ordering Order { get; set; }
		[Option('d', "desc")]
		public bool DescOrder { get; set; }
		[Option('i', "item")]
		public string? Item { get; set; }
		[Option('r', "rune")]
		public string? Rune { get; set; }
		[Option('s', "sockets")]
		public byte Sockets { get; set; }
		[Option("min-level")]
		public byte MinLevel { get; set; }
		[Option("max-level")]
		public byte MaxLevel { get; set; }
		[Option("skill-bonus")]
		public bool SkillBonus { get; set; }
		[Option("no-skill-bonus")]
		public bool NoSkillBonus { get; set; }
		[Option("charges")]
		public bool Charges { get; set; }
		[Option("no-charges")]
		public bool NoCharges { get; set; }
	}

	[Verb("shorts", HelpText = "Displays existing shortcuts.")]
	public record ShortcutsVerb : IVerb
	{
		[Option('s', "short")]
		public string? Shortcut { get; set; }
	}

	[Verb("classes", HelpText = "Displays existing classes.")]
	public record ClassesVerb : IVerb { }
}

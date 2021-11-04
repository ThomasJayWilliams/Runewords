using CommandLine;
using Runewords.Enums;
using Runewords.Interfaces;

namespace Runewords
{
	[Verb("runes", HelpText = "Displays existing runes.")]
	public record RunesVerb : IVerb
	{
		[Option('l', "lvl", HelpText = "Only display runes with specified level.")]
		public byte Level { get; set; }
		[Option('r', "rune", HelpText = "Only display specific rune.")]
		public string? Rune { get; set; }
	}

	[Verb("words", HelpText = "Displays existing runewords.")]
	public record RunewordsVerb : IVerb
	{
		[Option('l', "lvl", HelpText = "Only display runewords for specified level. If set, options [max-level] and [min-level] are ignored.")]
		public byte Level { get; set; }
		[Option('c', "class", HelpText = "Only display runewords for specified class.")]
		public string? Class { get; set; }
		[Option('o', "order", HelpText = "Apply ordering. Values: [class] - order by class, [level] - order by level. Orders by level by default.")]
		public Ordering Order { get; set; }
		[Option('d', "desc", HelpText = "Set descending order.")]
		public bool DescOrder { get; set; }
		[Option('i', "item", HelpText = "Only display runewords for specified item.")]
		public string? Item { get; set; }
		[Option('r', "rune", HelpText = "Only display runewords which contain specified rune.")]
		public string? Rune { get; set; }
		[Option('s', "sockets", HelpText = "Only display runewords for specified amount of sockets.")]
		public byte Sockets { get; set; }
		[Option("min-level", HelpText = "Only display runewords which level is greater than or equal to specified.")]
		public byte MinLevel { get; set; }
		[Option("max-level", HelpText = "Only display runewords which level is less than or equal to specified.")]
		public byte MaxLevel { get; set; }
		[Option("skill-bonus", HelpText = "Only display runewords with skill bonus for all classes.")]
		public bool SkillBonus { get; set; }
		[Option("no-skill-bonus", HelpText = "Only display runewords with no skill bonus for all classes.")]
		public bool NoSkillBonus { get; set; }
		[Option("charges", HelpText = "Only display runewords with charges attribute.")]
		public bool Charges { get; set; }
		[Option("no-charges", HelpText = "Only display runewords with no charges attribute.")]
		public bool NoCharges { get; set; }
	}

	[Verb("shorts", HelpText = "Displays existing shortcuts.")]
	public record ShortcutsVerb : IVerb
	{
		[Option('s', "short", HelpText = "Only display items which contain specified value.")]
		public string? Shortcut { get; set; }
	}

	[Verb("classes", HelpText = "Displays existing classes.")]
	public record ClassesVerb : IVerb { }
}

using Runewords.Interfaces;

namespace Runewords.Options
{
	public record ShortcutsOptions : IOptions
	{
		public string? Shortcut { get; set; }
	}
}

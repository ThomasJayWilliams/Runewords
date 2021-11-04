namespace Runewords.Models
{
	public record Shortcut
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		public override string ToString()
		{
			return $"{Name} - {Description}.";
		}
	}
}

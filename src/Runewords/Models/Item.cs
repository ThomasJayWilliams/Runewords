using System.Collections.Generic;

namespace Runewords.Models
{
	public record Item
	{
		public byte Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public virtual ICollection<RunewordItem> RunewordItems { get; set; } = new List<RunewordItem>();
	}
}

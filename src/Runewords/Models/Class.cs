using System.Collections.Generic;

namespace Runewords.Models
{
	public record Class
	{
		public byte Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public virtual ICollection<Runeword> Runewords { get; set; } = new List<Runeword>();
	}
}

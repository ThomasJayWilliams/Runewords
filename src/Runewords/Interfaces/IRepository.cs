using System.Collections.Generic;

namespace Runewords.Interfaces
{
	public interface IRepository<TOptions, TOutput>
		where TOptions : IOptions
		where TOutput : IOutput
	{
		IEnumerable<TOutput> Get(TOptions options);
	}
}

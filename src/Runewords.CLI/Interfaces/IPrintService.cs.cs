using Runewords.Interfaces;
using System.Collections.Generic;

namespace Runewords.CLI.Interfaces
{
	public interface IPrintService<TOutput>
		where TOutput : IOutput
	{
		void Print(IEnumerable<TOutput> output);
	}
}

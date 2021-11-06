using AutoMapper;
using Runewords.CLI.Interfaces;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;

namespace Runewords.CLI.Handlers
{
	public class RunewordHandler : BaseHandler<RunewordVerb, RunewordOutput, RunewordOptions>, IRunewordHandler
	{
		public RunewordHandler(IMapper mapper,
			IRunewordPrintService runewordPrintService,
			IRunewordRepository runewordRepository)
			: base(runewordRepository, runewordPrintService, mapper) { }
	}
}

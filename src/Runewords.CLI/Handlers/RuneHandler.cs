using AutoMapper;
using Runewords.CLI.Interfaces;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;

namespace Runewords.CLI.Handlers
{
	public class RuneHandler : BaseHandler<RuneVerb, RuneOutput, RuneOptions>, IRuneHandler
	{
		public RuneHandler(IMapper mapper,
			IRunePrintService runePrintService,
			IRuneRepository runeRepository)
			: base(runeRepository, runePrintService, mapper) { }
	}
}

using AutoMapper;
using Runewords.CLI.Interfaces;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;

namespace Runewords.CLI.Handlers
{
	public class ClassHandler : BaseHandler<ClassVerb, ClassOutput, ClassOptions>, IClassHandler
	{
		public ClassHandler(IMapper mapper,
			IClassPrintService classPrintService,
			IClassRepository classRepository)
			: base(classRepository, classPrintService, mapper) { }
	}
}

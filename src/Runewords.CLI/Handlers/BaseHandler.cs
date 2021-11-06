using AutoMapper;
using Runewords.CLI.Interfaces;
using Runewords.Interfaces;

namespace Runewords.CLI.Handlers
{
	public abstract class BaseHandler<TVerb, TOutput, TOptions> : IHandler<TVerb>
		where TVerb : class, IVerb
		where TOutput : IOutput
		where TOptions : IOptions
	{
		private readonly IRepository<TOptions, TOutput> _repository;
		private readonly IPrintService<TOutput> _printService;
		private readonly IMapper _mapper;

		protected BaseHandler(IRepository<TOptions, TOutput> repository,
			IPrintService<TOutput> printService,
			IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			_printService = printService;
		}

		public virtual void Handle(TVerb verb)
		{
			_printService.Print(
				_repository.Get(
					_mapper.Map<TOptions>(verb)));
		}
	}
}

using AutoMapper;
using CommandLine;
using Runewords.CLI.Extensions;
using Runewords.Interfaces;
using Runewords.Options;
using SimpleInjector;
using System;

namespace Runewords.CLI
{
	public class Program
	{
		private static IMapper _mapper = null!;
		private static Container _container = null!;

		public static void Main(string[] args)
		{
			try
			{
				_container = new Container();

				_container.RegisterCoreServices();
				_container.Verify();

				var configuration = new MapperConfiguration(cfg =>
				{
					cfg.RegisterMaps();
				});

				configuration.AssertConfigurationIsValid();

				_mapper = configuration.CreateMapper();

				Parser.Default.ParseArguments<
					RunesVerb, RunewordsVerb,
					ShortcutsVerb, ClassesVerb>(args)
				   .WithParsed<RunesVerb>(o => Handle<IRunesHandler, RunesOptions>(_mapper.Map<RunesOptions>(o)))
				   .WithParsed<RunewordsVerb>(o => Handle<IRunewordsHandler, RunewordsOptions>(_mapper.Map<RunewordsOptions>(o)))
				   .WithParsed<ShortcutsVerb>(o => Handle<IShortcutsHandler, ShortcutsOptions>(_mapper.Map<ShortcutsOptions>(o)))
				   .WithParsed<ClassesVerb>(o => Handle<IClassesHandler, ClassesOptions>(_mapper.Map<ClassesOptions>(o)));
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Fatal error. Details:{ex}");

				return;
			}
		}

		private static void Handle<THandler, TOptions>(TOptions options)
			where THandler : class, IHandler<TOptions>
			where TOptions : IOptions
		{
			_container.GetInstance<THandler>().Handle(options);
		}
	}
}

using CommandLine;
using Runewords.Extensions;
using Runewords.Interfaces;
using SimpleInjector;
using System;
using static System.Console;

namespace Runewords
{
	public class Program
	{
		private static Container _container = null!;

		public static void Main(string[] args)
		{
			Run(args);
		}

		private static void Run(string[] args)
		{
			try
			{
				_container = new Container();

				_container.RegisterCoreServices();
				_container.Verify();

				Parser.Default.ParseArguments<RunesVerb, RunewordsVerb, ShortcutsVerb, ClassesVerb>(args)
				   .WithParsed<RunesVerb>(o => Handle<IRunesHandler, RunesVerb>(o))
				   .WithParsed<RunewordsVerb>(o => Handle<IRunewordsHandler, RunewordsVerb>(o))
				   .WithParsed<ShortcutsVerb>(o => Handle<IShortcutsHandler, ShortcutsVerb>(o))
				   .WithParsed<ClassesVerb>(o => Handle<IClassesHandler, ClassesVerb>(o));
			}
			catch (Exception ex)
			{
				WriteLine($"Fatal error. Details:{ex}");

				return;
			}
		}

		private static void Handle<THandler, TVerb>(TVerb verb)
			where TVerb : IVerb
			where THandler : class, IHandler<TVerb>
		{
			var handler = _container.GetInstance<THandler>();

			handler.Handle(verb);
		}
	}
}

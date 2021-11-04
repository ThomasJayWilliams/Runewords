using CommandLine;
using Runewords.Handlers;
using System;
using static System.Console;

namespace Runewords
{
	class Program
	{
		static void Main(string[] args)
		{
			Run(args);
		}

		private static void Run(string[] args)
		{
			try
			{
				Parser.Default.ParseArguments<RunesVerb, RunewordsVerb, ShortcutsVerb, ClassesVerb>(args)
				   .WithParsed<RunesVerb>(HandleRunes)
				   .WithParsed<RunewordsVerb>(HandleRunewords)
				   .WithParsed<ShortcutsVerb>(HandleShortcuts)
				   .WithParsed<ClassesVerb>(HandleClasses);
			}
			catch (Exception ex)
			{
				WriteLine($"Fatal error. Details:{ex}");

				return;
			}
		}

		private static void HandleRunewords(RunewordsVerb options)
		{
			new RunewordsHandler().Handle(options);
		}

		private static void HandleRunes(RunesVerb options)
		{
			new RunesHandler().Handle(options);
		}

		private static void HandleShortcuts(ShortcutsVerb options)
		{
			new ShortcutsHandler().Handle(options);
		}

		private static void HandleClasses(ClassesVerb options)
		{
			new ClassesHandler().Handle(options);
		}
	}
}

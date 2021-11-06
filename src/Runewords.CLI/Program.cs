using CommandLine;
using Runewords.CLI.Extensions;
using Runewords.CLI.Interfaces;
using SimpleInjector;
using System;

namespace Runewords.CLI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				var container = new Container()
					.ConfigureServices();

				Parser.Default.ParseArguments<
					RuneVerb, RunewordVerb,
					ItemVerb, ClassVerb>(args)
				   .WithParsed<RuneVerb>(container.GetInstance<IRuneHandler>().Handle)
				   .WithParsed<RunewordVerb>(container.GetInstance<IRunewordHandler>().Handle)
				   .WithParsed<ItemVerb>(container.GetInstance<IItemHandler>().Handle)
				   .WithParsed<ClassVerb>(container.GetInstance<IClassHandler>().Handle);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Fatal error. Details:{ex}");

				return;
			}
		}
	}
}

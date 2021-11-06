using AutoMapper;
using Runewords.CLI.Handlers;
using Runewords.CLI.Interfaces;
using Runewords.CLI.Maps;
using Runewords.CLI.Services;
using Runewords.Extensions;
using SimpleInjector;

namespace Runewords.CLI.Extensions
{
	public static class ContainerExtensions
	{
		public static Container ConfigureServices(this Container container)
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<RuneOptionsProfile>();
				cfg.AddProfile<RunewordOptionsProfile>();
				cfg.AddProfile<ClassOptionsProfile>();
				cfg.AddProfile<ItemOptionsProfile>();

				cfg.RegisterCoreMaps();
			});

			configuration.AssertConfigurationIsValid();

			container.Register<IClassPrintService, ClassPrintService>();
			container.Register<IItemPrintService, ItemPrintService>();
			container.Register<IRunePrintService, RunePrintService>();
			container.Register<IRunewordPrintService, RunewordPrintService>();

			container.Register<IClassHandler, ClassHandler>();
			container.Register<IItemHandler, ItemHandler>();
			container.Register<IRuneHandler, RuneHandler>();
			container.Register<IRunewordHandler, RunewordHandler>();

			container.RegisterInstance(configuration.CreateMapper());
			container.RegisterCoreServices();
			container.Verify();

			return container;
		}
	}
}

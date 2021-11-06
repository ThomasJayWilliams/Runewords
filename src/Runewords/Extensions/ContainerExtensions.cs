using Runewords.Interfaces;
using Runewords.Repositories;
using SimpleInjector;

namespace Runewords.Extensions
{
	public static class ContainerExtensions
	{
		public static Container RegisterCoreServices(this Container container)
		{
			container.Register<IRuneRepository, RuneRepository>();
			container.Register<IRunewordRepository, RunewordRepository>();
			container.Register<IClassRepository, ClassRepository>();
			container.Register<IItemRepository, ItemRepository>();

			// since CLI app makes only one DB call per run, singleton should fit the needs
			container.RegisterInstance(new RunewordsDbContext());

			return container;
		}
	}
}

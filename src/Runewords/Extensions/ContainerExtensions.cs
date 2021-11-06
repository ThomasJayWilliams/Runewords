using Runewords.Repositories;
using Runewords.Interfaces;
using Runewords.Services;
using SimpleInjector;

namespace Runewords.Extensions
{
	public static class ContainerExtensions
	{
		public static Container RegisterCoreServices(this Container container)
		{
			container.Register<IDataReader, FileDataReader>();
			container.Register<IRuneRepository, RuneRepository>();
			container.Register<IRunewordRepository, RunewordRepository>();
			container.Register<IClassRepository, ClassRepository>();
			container.Register<IItemRepository, ItemRepository>();

			return container;
		}
	}
}

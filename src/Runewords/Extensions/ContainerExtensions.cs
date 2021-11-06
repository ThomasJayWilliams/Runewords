using Runewords.Handlers;
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
			container.Register<IRunesHandler, RunesHandler>();
			container.Register<IRunewordsHandler, RunewordsHandler>();
			container.Register<IClassesHandler, ClassesHandler>();
			container.Register<IShortcutsHandler, ShortcutsHandler>();

			return container;
		}
	}
}

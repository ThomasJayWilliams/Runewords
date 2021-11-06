using AutoMapper;
using Runewords.CLI.Maps;

namespace Runewords.CLI.Extensions
{
	public static class IMapperConfigurationExpressionExtensions
	{
		public static IMapperConfigurationExpression RegisterMaps(this IMapperConfigurationExpression cfg)
		{
			cfg.AddProfile<RunesOptionsProfile>();
			cfg.AddProfile<RunewordsOptionsProfile>();
			cfg.AddProfile<ClassesOptionsProfile>();
			cfg.AddProfile<ShortcutsOptionsProfile>();

			return cfg;
		}
	}
}

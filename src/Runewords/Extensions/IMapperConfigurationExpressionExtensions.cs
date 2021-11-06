using AutoMapper;
using Runewords.Maps;

namespace Runewords.Extensions
{
	public static class IMapperConfigurationExpressionExtensions
	{
		public static IMapperConfigurationExpression RegisterCoreMaps(this IMapperConfigurationExpression cfg)
		{
			cfg.AddProfile<ClassOutputProfile>();
			cfg.AddProfile<ItemOutputProfile>();
			cfg.AddProfile<RuneOutputProfile>();
			cfg.AddProfile<RunewordOutputProfile>();

			return cfg;
		}
	}
}

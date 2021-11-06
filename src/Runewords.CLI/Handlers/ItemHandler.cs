using AutoMapper;
using Runewords.CLI.Interfaces;
using Runewords.Interfaces;
using Runewords.Models.Output;
using Runewords.Options;

namespace Runewords.CLI.Handlers
{
	public class ItemHandler : BaseHandler<ItemVerb, ItemOutput, ItemOptions>, IItemHandler
	{
		public ItemHandler(IMapper mapper,
			IItemPrintService itemPrintService,
			IItemRepository itemRepository)
			: base(itemRepository, itemPrintService, mapper) { }
	}
}

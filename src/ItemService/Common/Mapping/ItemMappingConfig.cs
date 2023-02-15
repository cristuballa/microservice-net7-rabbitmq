using ItemService.Models;
using Mapster;

namespace ItemService.Common.Mapping;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
         config.NewConfig<ItemRequest, Item>()
            .Map(dest => dest, src => src);
    }
}
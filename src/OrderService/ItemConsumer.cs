using MassTransit;

namespace OrderService;
internal class ItemConsumer : IConsumer<Item>
{
    public async Task Consume(ConsumeContext<Item> context)
    {
        var item = context.Message;
        await Console.Out.WriteLineAsync($"Item with id {item.Id} and name {item.Name} was created");
    }
}
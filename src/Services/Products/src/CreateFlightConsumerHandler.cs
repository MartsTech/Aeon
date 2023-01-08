using BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;

namespace Products;

public class CreateProductConsumerHandler : IConsumer<ProductCreated>
{
    public Task Consume(ConsumeContext<ProductCreated> context)
    {
        Console.WriteLine("It's for test");
        return Task.CompletedTask;
    }
}
namespace Company.Consumers
{
    using MassTransit;

    public class PcInfoConsumerDefinition :
        ConsumerDefinition<PcInfoConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<PcInfoConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
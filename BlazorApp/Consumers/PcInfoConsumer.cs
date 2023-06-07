namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using System;
    using Microsoft.AspNetCore.SignalR;
    using MtRabbit.Hubs;
    using MtRabbit;

    public class PcInfoConsumer :
        IConsumer<PcInfo>
    {
        public PcInfoConsumer(IHubContext<PcInfoHub> hubContext)
        {
            _hubContext = hubContext;
        }

        readonly IHubContext<PcInfoHub> _hubContext;
        readonly PCInfoReader pCInfoReader = new PCInfoReader();
        public Task Consume(ConsumeContext<PcInfo> context)
        {
            Console.WriteLine(context.Message.Ram);
            _hubContext.Clients.All.SendAsync("broadcastMessage", new PcInfo
            {
                Ram = pCInfoReader.ReadRam(),
                CpuUsage = pCInfoReader.ReadCPU(),
                ProccessorCount = pCInfoReader.ReadProcessorCount(),
            });
            return Task.CompletedTask;
        }
    }
}
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace MtRabbit
{
    public class PcInfoPublisher : BackgroundService
    {
        IBus _bus;
        public PcInfoPublisher(IBus bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            PCInfoReader pCInfoReader = new PCInfoReader();

            while (true)
            {
                await _bus.Publish(new PcInfo
                {
                    Ram = pCInfoReader.ReadRam(),
                    CpuUsage = pCInfoReader.ReadCPU(),
                    ProccessorCount = pCInfoReader.ReadProcessorCount(),
                });
                await Task.Delay(500);
            }
        }
    }
}

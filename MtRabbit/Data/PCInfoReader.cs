using System;
using System.Diagnostics;

namespace MtRabbit
{
    public class PCInfoReader
    {
        public float Ram { get; set; }
        public int ProccessorCount { get; set; }
        public float CpuUsage { get; set; }

        public PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        public PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");        
        
        public float ReadCPU()
        {
            CpuUsage = cpuCounter.NextValue();
            return CpuUsage;
        }
        public float ReadRam()
        {
            Ram = ramCounter.NextValue();
            return Ram;
        }
        public int ReadProcessorCount()
        {
            ProccessorCount = Environment.ProcessorCount;
            return ProccessorCount;
        }
    }
}
namespace Contracts
{
    public record PcInfo
    {
        public float Ram { get; set; }
        public int ProccessorCount { get; set; }
        public float CpuUsage { get; set; }
    }
}
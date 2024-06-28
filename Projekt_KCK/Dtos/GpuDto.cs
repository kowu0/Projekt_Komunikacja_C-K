namespace Projekt_KCK.Dtos
{
    public class GpuDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public float CoreClock { get; set; }
    }
}

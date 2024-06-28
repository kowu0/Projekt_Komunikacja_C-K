namespace Projekt_KCK.Dtos
{
    public class DiskDto
    {
       public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public float ReadSpeed { get; set; }
        public float WriteSpeed { get; set; }
    }
}

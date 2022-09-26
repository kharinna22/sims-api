namespace SimsAPI.Models
{
    public class Sim
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        public bool IsMuerto { get; set; }
        public bool IsMujer { get; set; }
    }
}

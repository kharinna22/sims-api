namespace SimsAPI.Models
{
    public class AddSimRequest
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        public bool IsMuerto { get; set; }
        public bool IsMujer { get; set; }
    }
}

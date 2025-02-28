namespace P01_2022MP653_2023GL651.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int AdministradorId { get; set; }
        public int NumeroEspacios { get; set; }
    }
}
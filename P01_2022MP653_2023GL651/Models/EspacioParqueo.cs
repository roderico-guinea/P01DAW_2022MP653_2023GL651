namespace P01_2022MP653_2023GL651.Models
{
    public class EspacioParqueo
    {
        public int Id { get; set; }
        public int SucursalId { get; set; }
        public int Numero { get; set; }
        public string? Ubicacion { get; set; }
        public decimal CostoPorHora { get; set; }
        public string? Estado { get; set; }
    }
}

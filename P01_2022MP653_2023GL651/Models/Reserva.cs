public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int EspacioId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int CantidadHoras { get; set; }
}
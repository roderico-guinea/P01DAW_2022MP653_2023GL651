using Microsoft.EntityFrameworkCore;
using P01_2022MP653_2023GL651.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<EspacioParqueo> EspaciosParqueo { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
}
using System;
using BaseDeDatosMySql.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatosMySql.Context
{
    public class RegistrosVentContext : DbContext
    {
        public RegistrosVentContext(DbContextOptions<RegistrosVentContext> opciones) : base(opciones)
        {
        }
        public RegistrosVentContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<UnidadesVendidas> UnidadesVendidas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<RegresionLineal> RegresionesLineales { get; set; }
        public DbSet<DatosComparativosDiasSiguientes> DatosComparativosDiasSiguientes { get; set; }
        public DbSet<DatosComparativosDiasAnteriores> DatosComparativosDiasAnteriores { get; set; }
        public DbSet<PredicDifRealFaltante> PredicDifRealFaltantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "server=localhost;database=RegistrosVentas;user=root;password=martes13",
                    new MySqlServerVersion(new Version(8, 0, 41))
                );
            }
        }
    }
}
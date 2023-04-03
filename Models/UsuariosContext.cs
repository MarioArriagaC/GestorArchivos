using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GestorArchivo.Models
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
        {
        }

        public DbSet<UsuariosItem> UsuariosItems { get; set; } = null!;
    }
}
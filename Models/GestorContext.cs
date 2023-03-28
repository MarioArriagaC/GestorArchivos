using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GestorArchivo.Models
{
    public class GestorContext : DbContext
    {
        public GestorContext(DbContextOptions<GestorContext> options)
            : base(options)
        {
        }

        public DbSet<GestorItem> GestorItems { get; set; } = null!;
    }
}
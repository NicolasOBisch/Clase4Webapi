using Clase4Webapi.Models;
using Microsoft.EntityFrameworkCore;

public class NomyApeContext : DbContext
{
    public NomyApeContext(DbContextOptions<NomyApeContext> options) : base(options){  }

    public DbSet<NomyApe> NomyApes { get; set; }
}
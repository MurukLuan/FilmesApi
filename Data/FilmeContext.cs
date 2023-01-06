using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions opts) : base(opts) 
    {
    }
    public DbSet<Filme> Filmes { get; set; }
}

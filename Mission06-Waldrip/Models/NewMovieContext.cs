using Microsoft.EntityFrameworkCore;

namespace Mission06_Waldrip.Models;

public class NewMovieContext : DbContext
{
    public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options)
    {
        
    }
    
    public DbSet<NewMovie> Movies { get; set; }
}
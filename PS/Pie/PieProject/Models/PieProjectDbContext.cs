using Microsoft.EntityFrameworkCore;

namespace PieProject.Models;

public class PieProjectDbContext(DbContextOptions<PieProjectDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Pie> Pies { get; set; }
}

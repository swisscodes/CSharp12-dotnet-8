using Microsoft.EntityFrameworkCore;
using PieProject.Models;
using PieProject.Models.Repository;

static partial class Program
{
    public static void AllServeices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<IPieRepo, PieRepo>();
        builder.Services.AddDbContext<PieProjectDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("PieProjectDbContextConn"));
        });
    }
}


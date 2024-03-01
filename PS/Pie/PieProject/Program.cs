using PieProject.Models;

var builder = WebApplication.CreateBuilder(args);

//services
AllServeices(builder);

var app = builder.Build();


app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.MapDefaultControllerRoute();
DbInit.Seed(app);

app.Run();

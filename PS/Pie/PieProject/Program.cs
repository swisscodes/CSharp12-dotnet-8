using PieProject.Models;

var builder = WebApplication.CreateBuilder(args);

//built in services
builder.Services.AddSession(); //for sessions
builder.Services.AddHttpContextAccessor();// to be able use the IHttpContextAccessor
builder.Services.AddControllersWithViews();

// Our services
AllServeices(builder);

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.MapDefaultControllerRoute();
DbInit.Seed(app);

app.Run();

using PieProject.Models;

var builder = WebApplication.CreateBuilder(args);

//built in services
builder.Services.AddSession(); //for sessions
builder.Services.AddHttpContextAccessor();// to be able use the IHttpContextAccessor
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.MapRazorPages();
DbInit.Seed(app);

app.Run();

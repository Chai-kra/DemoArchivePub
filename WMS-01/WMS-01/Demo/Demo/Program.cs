global using Demo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSqlServer<DB>($@"
    Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename={builder.Environment.ContentRootPath}\DB.mdf;
"); // Built in databaase with the project

var app = builder.Build();
app.UseHttpsRedirection(); //redirects HTTP requests to HTTPS
app.UseStaticFiles();   //
app.MapDefaultControllerRoute(); //defult url pattern
app.Run();

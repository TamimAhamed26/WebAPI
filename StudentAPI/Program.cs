using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); 

builder.Services.AddRazorPages(); 

builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();    

app.Run();

using EmployeeManagement.Context.DataContext;
using EmployeeManagement.Web.Repositories;
using EmployeeManagement.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*
 
dotnet ef migrations add InitialCreate --project EmployeeManagement.Context --startup-project EmployeeManagement.Web
dotnet ef database update --project EmployeeManagement.Context --startup-project EmployeeManagement.Web


*/


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();
builder.Services.AddScoped<ICsvRepository, CsvService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using CredensPet.Infrastructure;
using DataAccessLayer.Repository;
using BusinessLogicLayer;
using CredensPet.Infrastructure.DTO;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CredensContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<ProjectDTO>), typeof(ProjectRepository));
builder.Services.AddScoped(typeof(IService<ProjectDTO>), typeof(ProjectService));

builder.Services.AddScoped(typeof(IRepository<BranchDTO>), typeof(BranchRepository));
builder.Services.AddScoped(typeof(IService<BranchDTO>), typeof(BranchService));

builder.Services.AddScoped(typeof(IRepository<ContactDTO>), typeof(ContactRepository));
builder.Services.AddScoped(typeof(IService<ContactDTO>), typeof(ContactService));

builder.Services.AddScoped(typeof(IRepository<UserDTO>), typeof(UserRepository));
builder.Services.AddScoped(typeof(IService<UserDTO>), typeof(UserService));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

using AutoMapper;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using CredensPet.Infrastructure;
using DataAccessLayer.Repository;
using BusinessLogicLayer;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.MappingProfiles;
using Presentation.Profiles;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CredensContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<ProjectDTO>), typeof(ProjectRepository));
builder.Services.AddScoped(typeof(IService<ProjectDTO>), typeof(ProjectService));

var config = new MapperConfiguration(c => {
    c.AddProfile<ProjectMapperConfiguration>();
    c.AddProfile<ProjectDTOMapperConfiguration>();
});
builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());

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

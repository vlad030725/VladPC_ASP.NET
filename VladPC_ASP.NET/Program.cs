using System.Text.Json.Serialization;
using DAL;
using Interfaces.Repository;
using DAL.RepositoryPgs;
using Interfaces.Services;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DomainModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole<int>>()
.AddEntityFrameworkStores<ComputerStoreContext>();

builder.Services.AddDbContext<ComputerStoreContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Companies"), b => b.MigrationsAssembly("dataaccess")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient<IDbRepos, DbReposPgs>();
builder.Services.AddTransient<ICustomService, CustomService>();
builder.Services.AddTransient<ILoadFileService, LoadFileService>();
builder.Services.AddTransient<IProcurementService, ProcurementService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ITypeProductService, TypeProductService>();
builder.Services.AddTransient<ITypeMemoryService, TypeMemoryService>();
builder.Services.AddTransient<ISocketService, SocketService>();
builder.Services.AddTransient<IFormFactorService, FormFactorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ComputerStoreContext = scope.ServiceProvider.GetRequiredService<ComputerStoreContext>();
    //----
    await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowCredentials().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

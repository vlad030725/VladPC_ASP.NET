using System.Text.Json.Serialization;
using DAL;
using Interfaces.Repository;
using DAL.RepositoryPgs;
using Interfaces.Services;
using BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ComputerStoreContext>(opt =>
opt.UseInMemoryDatabase("ComputerStore"));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

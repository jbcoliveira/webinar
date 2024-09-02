using Microsoft.EntityFrameworkCore;
using WebinarEF.Data;
using WebinarEF.Interfaces;
using WebinarEF.Repositories;
using WebinarEF.UnitOfWork;

namespace WebinarEF;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });;
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swaggerGenOptions => { swaggerGenOptions.EnableAnnotations(); });

        builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite("./Data/DataWebinarEF.db"));

        RegisterScoppedSevices(builder);

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        app.MapControllers();
        app.Run();
    }

    private static void RegisterScoppedSevices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IUnitOfWork, TestUnitOfWork>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
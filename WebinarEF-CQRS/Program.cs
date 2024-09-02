using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebinarEFCQRS.Data;

namespace WebinarEFCQRS;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swaggerGenOptions => { swaggerGenOptions.EnableAnnotations(); });

        builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite("./Data/DataWebinarEF.db"));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        app.MapControllers();
        app.Run();
    }

}
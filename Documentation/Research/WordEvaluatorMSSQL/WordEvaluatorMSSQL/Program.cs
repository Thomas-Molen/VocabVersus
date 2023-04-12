using Microsoft.EntityFrameworkCore;
using WordEvaluatorMSSQL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to DI

// Add WebAPI Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add DbContext
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=DESKTOP-JA0B7PU\\SQLEXPRESS;Database=WordEvaluatorMSSQLDb;Trusted_Connection=True;Encrypt=False"));

var app = builder.Build();

// Ensure Database is created
using (var scope = app.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<DatabaseContext>())
    {
        context?.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

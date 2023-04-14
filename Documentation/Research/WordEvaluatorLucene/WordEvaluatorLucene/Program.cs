using WordEvaluatorLucene.Lucene;

var builder = WebApplication.CreateBuilder(args);

// Add services to DI
builder.Services.AddSingleton<WordEngine>();

// Add WebAPI Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

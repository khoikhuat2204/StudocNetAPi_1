using StudocNetAPi_1;
using StudocNetAPi_1.Data;
using StudocNetAPi_1.Repositories;
using StudocNetAPi_1.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling =
            ReferenceLoopHandling.Ignore;
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<Seed>();
//Add DI
AddDI(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);


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

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }

}

 void AddDI(IServiceCollection services)
{
    services.AddScoped<PokemonRepository>();
    services.AddScoped<IPokemonService, PokemonService>();
    services.AddScoped<OwnerRepository>();
    services.AddScoped<IOwnerService, OwnerService>();
    services.AddScoped<CountryRepository>();
}
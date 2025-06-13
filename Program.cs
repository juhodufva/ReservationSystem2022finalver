using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReservationSystem2022.Models;
using Microsoft.Data.Sqlite;
using ReservationSystem2022.Repositories;
using ReservationSystem2022.Services;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReservationContext>(opt =>
    opt.UseSqlite("Data Source=reservation.db"));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Reservation API",
        Description = "An ASP.NET Core Web API for managing items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // XML comments configuration (optional)
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

var app = builder.Build();

// Ensure database schema exists, even if an old database file is missing tables
using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<ReservationContext>();

    // create DB if it does not exist
    dbcontext.Database.EnsureCreated();

    // verify the Items table exists; if not, recreate the database
    var conn = dbcontext.Database.GetDbConnection();
    conn.Open();
    try
    {
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Items'";
        var count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count == 0)
        {
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
        }
    }
    finally
    {
        conn.Close();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

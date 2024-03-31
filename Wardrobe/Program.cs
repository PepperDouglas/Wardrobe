using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Wardrobe.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddDbContext<WardrobeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WardrobeDB"))
);

//builder.Services.AddTransient<IReviewService, ReviewService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();
app.UseSwaggerUI();


app.Run();


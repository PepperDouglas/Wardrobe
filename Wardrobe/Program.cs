using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Wardrobe.Core.Interfaces;
using Wardrobe.Core.Services;
using Wardrobe.Data.Contexts;
using Wardrobe.Data.Interfaces;
using Wardrobe.Data.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddDbContext<WardrobeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WardrobeDB"))
);

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepo, OrderRepo>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();
app.UseSwaggerUI();


app.Run();


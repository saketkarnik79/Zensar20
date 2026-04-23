using DemoCopilotSOLID.Services;

var builder = WebApplication.CreateBuilder(args);

// DI registrations for Order services
builder.Services.AddTransient<IOrderCalculator, OrderCalculator>();

// Register discount strategies (open for extension)
builder.Services.AddTransient<IDiscountStrategy, PremiumDiscountStrategy>();
builder.Services.AddTransient<IDiscountStrategy, NoDiscountStrategy>();

builder.Services.AddScoped<IOrderRepository>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var conn = config.GetConnectionString("DefaultConnection") ?? "connection String";
    return new SqlOrderRepository(conn);
});

builder.Services.AddTransient<INotificationService>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var host = config["Smtp:Host"] ?? "smtp.example.com";
    var from = config["Smtp:From"] ?? "sales@shop.com";
    return new SmtpNotificationService(host, from);
});

// Add services to the container.
builder.Services.AddAuthorization();

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

// ... endpoints ...
app.Run();

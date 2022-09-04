using Microsoft.EntityFrameworkCore;
using Trisha.Services.Email.DbContexts;
using Trisha.Services.Email.Extension;
using Trisha.Services.Email.Messaging;
using Trisha.Services.Email.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionBuilder.UseSqlServer(connectionString);

//services.AddHostedService<RabbitMQPaymentConsumer>();
//services.AddHostedService<RabbitMQCheckoutConsumer>();
builder.Services.AddSingleton(new EmailRepository(optionBuilder.Options));
builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();

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
app.UseAzureServiceBusConsumer();

app.Run();

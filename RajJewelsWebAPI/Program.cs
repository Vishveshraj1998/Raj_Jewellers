using RajJewelsWebAPI.Helper;
using RajJewelsWebAPI.IServices;
using RajJewelsWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddScoped<IRajServices, RajServices>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Automapper
builder.Services.AddAutoMapper(typeof(AutomappingProfiles).Assembly);

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
      builder => {
         builder.WithOrigins("http://localhost:4200") // specifying the allowed origin
                 .WithMethods("*") // defining the allowed HTTP method
                  .AllowAnyHeader(); // allowing any header to be sent
      });
});

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

app.UseCors(policyName);

app.Run();


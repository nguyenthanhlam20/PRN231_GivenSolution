using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Q1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100);
    // Bật tính năng EnableQuery
    options.EnableQueryFeatures();

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddAutoMapper(typeof(Program).Assembly);*/
builder.Services.AddDbContext<Spring24B1_ScriptContext>();
builder.Services.AddCors(builder =>
    builder.AddPolicy("corsapp", b => { b.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); }));


//MAPPER
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new Q1.Mapper.AutoMapper()); });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

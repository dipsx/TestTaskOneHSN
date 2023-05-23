using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Mediator;
using DotNetCore.Results;
using DotNetCore.Security;
using DotNetCore.Services;
using Microsoft.EntityFrameworkCore;
using TestTask.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();
builder.Services.AddJsonStringLocalizer();
builder.Services.AddResultService();
builder.Services.AddHashService();
builder.Services.AddJwtService();
builder.Services.AddAuthorization().AddAuthentication().AddJwtBearer();
builder.Services.AddContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext))));
builder.Services.AddClassesMatchingInterfaces(nameof(TestTask));
builder.Services.AddMediator(nameof(TestTask));
builder.Services.AddSwaggerDefault();
builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();


var app = builder.Build();

app.UseException();
app.UseHttps();
app.UseLocalization("en", "fr");
app.UseSwagger().UseSwaggerUI();
app.UseRouting();
app.MapControllers();

app.Run();

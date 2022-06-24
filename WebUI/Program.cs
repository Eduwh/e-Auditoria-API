using CurrentWeather.Infrastructure;
using eAuditoria.Infrastructure.Context;
using eAuditoria.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
//Adding policy to make so it is required that the user is logged in the Api unless AllowAnonymous
//builder.Services.AddMvc(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//}).AddXmlSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger( x => x.SerializeAsV2 = true );
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var context = services.GetService<ApplicationDbContext>();
    new ClienteInitializer(context).Initialize();
    new FilmeInitializer(context).Initialize();
    new LocacaoInitializer(context).Initialize();    
}

app.Run();
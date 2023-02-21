using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Warehouse.Business;
using Warehouse.DataAccess;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Users;
using Warehouse.Infrasturucture;
using Warehouse.Infrasturucture.Utilities.Security.Encryption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region Authentication
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Warehouse.Infrasturucture.Utilities.Security.Jwt.TokenOptions>();

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
  .AddJwtBearer(option =>
  {
      option.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidIssuer = tokenOptions.Issuer,
          ValidateAudience = true,
          ValidAudience = tokenOptions.Audience,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
          ClockSkew = TimeSpan.Zero
      };
  });
#endregion

#region Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(conf =>
{
    conf.IdleTimeout = TimeSpan.FromHours(1);
    conf.Cookie.HttpOnly = false;
    conf.Cookie.IsEssential = true;
    conf.Cookie.SameSite = SameSiteMode.None;
    conf.Cookie.SecurePolicy = CookieSecurePolicy.Always;

});
#endregion


builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDbConnection")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
{
    config.Stores.MaxLengthForKeys = 128;
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequiredLength = 4;
    config.Password.RequiredUniqueChars = 0;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;

})
  .AddEntityFrameworkStores<WarehouseDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();
builder.Services.AddInfrastructureServices();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouse.WebApi", Version = "v1" });

    //include description from method xml comments
    //var path = Path.Combine(AppContext.BaseDirectory, "Portfolio.WebApi.xml");
    //c.IncludeXmlComments(path);

    //add jwt security bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "please insert token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                   {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference= new OpenApiReference
                               {
                                   Type=ReferenceType.SecurityScheme,
                                   Id="Bearer"
                               }
                           },
                           new string[] { }
                       }
                   });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

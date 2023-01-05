using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReviewsPortal.Models;
using ReviewsPortal.Models.Initializers;
using ReviewsPortal.Models.Validators;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddTransient<IUserValidator<User>, CustomUserValidator>();

builder.Services.AddTransient<IPasswordValidator<User>,
            CustomPasswordValidator>(serv => new CustomPasswordValidator(6));

builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(opts => {
    opts.Password.RequiredLength = 5;   
    opts.Password.RequireNonAlphanumeric = false;  
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireDigit = true;
    opts.User.RequireUniqueEmail = true;
    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz";
}).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();





builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = "test";
        options.AppSecret = "test";
    })
    .AddGoogle(options =>
    {
        options.ClientId = "test";
        options.ClientSecret = "test";
    });

/*builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       Configuration.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   })
   .AddFacebook(options =>
   {
       IConfigurationSection FBAuthNSection =
       Configuration.GetSection("Authentication:FB");
       options.ClientId = FBAuthNSection["ClientId"];
       options.ClientSecret = FBAuthNSection["ClientSecret"];
   });*/













var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

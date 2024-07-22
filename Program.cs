using CoreLayer.Service.Chats;
using CoreLayer.Service.Chats.ChatGroups;
using CoreLayer.Service.Role;
using CoreLayer.Service.User;
using CoreLayer.Service.User.UserGroups;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Signalr.Hubs;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Add Db Context
builder.Services.AddDbContext<EchatDbContex>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Add service in the section
builder.Services.AddScoped<IChatService , ChatService>();
builder.Services.AddScoped<IChatGroupService , ChatGroupService>();
builder.Services.AddScoped<IRoleService , RoleService>();
builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddScoped<IUserGroupService , UserGroupService>();
//Add Signalr
builder.Services.AddSignalR();

//Add Authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(option =>
{
    option.LoginPath = "/auth/login";
    option.LogoutPath = "/auth/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
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
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/Chat");
});*/
app.MapHub<ChatHub>("/Chat");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

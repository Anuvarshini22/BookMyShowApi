using BookMyShow.Context;
using BookMyShow.Contracts;
using BookMyShow.Service;
using BookMyShow.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Text;
using Container = SimpleInjector.Container;
using BookMyShow.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvcCore();

var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
builder.Services.AddSimpleInjector(container, options =>
 {
     options.AddAspNetCore().AddControllerActivation();
 });
container.Register<IMovieService,MovieService>();
container.Register<ITheatreService,TheatreService>();
container.Register<IShowService,ShowService>();
container.Register<ISeatService,SeatService>();
container.Register<ITicketService,TicketService>();
container.Register<IAuthService, AuthService>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
     {
         options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
     });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.Services.UseSimpleInjector(container);
container.Verify();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

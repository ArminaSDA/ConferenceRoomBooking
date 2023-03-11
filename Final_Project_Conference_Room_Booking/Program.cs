using Final_Project_Conference_Room_Booking.Controllers;
using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>(); 
builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
builder.Services.AddScoped<IUnavailabilityPeriodRepository, UnavailabilityPeriodRepository>();
builder.Services.AddScoped<IUnavailabilityPeriodService, UnavailabilityPeriodService>(); 

builder.Services.AddDbContext<ConferenceRoomBookingContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    
//    .AddEntityFrameworkStores<ConferenceRoomBookingContext>();


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ConferenceRoomBookingContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();


//inject classes into Program
builder.Services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>();
builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
builder.Services.AddScoped<IReservationHolderRepository, ReservationHolderRepository>();
builder.Services.AddScoped<IReservationHolderService, ReservationHolderService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//app.UseMvcWithDefaultRoute();
app.Run();

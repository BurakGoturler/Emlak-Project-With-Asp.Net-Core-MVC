using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Servis olarak Authentication kullan. Bu uygulama Authentication gerektiren bir uygulama.
// CookieAuthenticationDefaults.AuthenticationScheme) ile cookie tabanlý bir Authentication kullan demiþ olduk.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
{
	// cookie'nin varsayýlanlarýnýn eklendiði kýsým.
	c.Cookie.Name = "LoginCookie";
	c.LoginPath = "/Account/Login";
	c.LogoutPath = "/Account/Logout";
	c.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Bu cookie'nin süresi ne kadar? Bu oturumun süresi ne kadar sürecek.
	c.SlidingExpiration = true; // inaktif kaldýðým sürede (o süreyi 5 dakika olarak ayarladýk) oturumu sonlandýr. Sayfa deðiþikliðinde oturum süresini sayma demiþ olduk.
});

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
app.UseAuthorization(); // yetkilendirme

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
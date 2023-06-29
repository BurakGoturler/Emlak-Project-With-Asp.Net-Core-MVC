using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Servis olarak Authentication kullan. Bu uygulama Authentication gerektiren bir uygulama.
// CookieAuthenticationDefaults.AuthenticationScheme) ile cookie tabanl� bir Authentication kullan demi� olduk.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
{
	// cookie'nin varsay�lanlar�n�n eklendi�i k�s�m.
	c.Cookie.Name = "LoginCookie";
	c.LoginPath = "/Account/Login";
	c.LogoutPath = "/Account/Logout";
	c.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Bu cookie'nin s�resi ne kadar? Bu oturumun s�resi ne kadar s�recek.
	c.SlidingExpiration = true; // inaktif kald���m s�rede (o s�reyi 5 dakika olarak ayarlad�k) oturumu sonland�r. Sayfa de�i�ikli�inde oturum s�resini sayma demi� olduk.
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
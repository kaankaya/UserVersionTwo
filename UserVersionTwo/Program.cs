var builder = WebApplication.CreateBuilder(args);
//Mvc i�in gerekli tan�mlama
builder.Services.AddControllersWithViews();

var app = builder.Build();
//statik dosyalar�n kullan�m� i�in
app.UseStaticFiles();
app.UseRouting();


//link yap�land�rmas�
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();

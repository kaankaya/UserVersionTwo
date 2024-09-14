var builder = WebApplication.CreateBuilder(args);
//Mvc için gerekli tanýmlama
builder.Services.AddControllersWithViews();

var app = builder.Build();
//statik dosyalarýn kullanýmý için
app.UseStaticFiles();
app.UseRouting();


//link yapýlandýrmasý
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();

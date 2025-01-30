using Microsoft.EntityFrameworkCore;
using MouseTracker.Application.Extensions;
using MouseTracker.Infrastructure.Extensions;
using MouseTracker.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 1. Регистрация сервисов
builder.Services.AddControllersWithViews();

// 2. Настройка БД (SQLite для примера)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Регистрация зависимостей Clean Architecture
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// 4. Конфигурация Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 5. Маршрутизация для MVC и API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 6. Автоматическое применение миграций
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
using Microsoft.EntityFrameworkCore;
using qrMenu.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=menu.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // 🚧 Veritabanı varsa dokunma, yoksa oluştur
    context.Database.EnsureCreated(); // veya: context.Database.EnsureCreated();

    // 👤 Admin kullanıcı yoksa ekle
    if (!context.AdminUsers.Any())
    {
        context.AdminUsers.Add(new AdminUser
        {
            Username = "admin",
            Password = "1234" // Sonra hash’lenir
        });
        context.SaveChanges();
    }
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UDPChat_server.Models;

namespace UDPChat_server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // // Добавление сервиса Identity
            // services.AddIdentity<User, IdentityRole>()
            //     .AddEntityFrameworkStores<YourDbContext>();
            //
            // // Конфигурация аутентификации
            // services.Configure<IdentityOptions>(options =>
            // {
            //     // Настройки пароля
            //     options.Password.RequireDigit = true;
            //     options.Password.RequiredLength = 8;
            //     // Другие настройки пароля...
            //
            //     // Настройки блокировки пользователя
            //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //     options.Lockout.MaxFailedAccessAttempts = 5;
            //     // Другие настройки блокировки пользователя...
            //
            //     // Настройки Cookie
            //     options.SignIn.RequireConfirmedEmail = false;
            //     options.SignIn.RequireConfirmedPhoneNumber = false;
            //     // Другие настройки Cookie...
            // });
            //
            // // Добавление сервиса аутентификации
            // services.AddAuthentication();
            //
            // // Добавление сервиса авторизации
            // services.AddAuthorization();
            //
            // // Добавление сервиса базы данных
            // services.AddDbContext<YourDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("YourDbConnection")));

            // Чтение настроек из appsettings.json
            services.Configure<ChatDatabaseSettings>(Configuration.GetSection(nameof(ChatDatabaseSettings)));
            services.AddSingleton<IChatDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ChatDatabaseSettings>>().Value);
            
            // Регистрация MongoDB клиента
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IChatDatabaseSettings>();
                return new MongoClient(settings.ConnectionString);
            });
            
            // Регистрация репозитория
            services.AddSingleton<IChatRepository, ChatRepository>();
            // services.AddScoped<IChatRepository, ChatRepository>();
            
            services.AddSingleton<IUserRepository, UserRepository>();
            
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Backend.Data;
using Backend.Middleware;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            });

            // add scoped
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // add auto mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // add my middleware
            app.UseMiddleware<ExceptionMiddleware>();

            // add StatusCode
            app.UseStatusCodePagesWithReExecute("/errors/{0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
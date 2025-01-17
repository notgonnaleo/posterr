using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Contexts;
using Posterr.Infrastructure.Repositories;
using Posterr.Infrastructure.Services;

namespace Posterr.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // In memory for test
            //builder.Services.AddDbContext<AppDbContext>(options => 
            //    options.UseInMemoryDatabase("PosterrDb"));

            // Real local database
            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("PosterrDb")));

            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

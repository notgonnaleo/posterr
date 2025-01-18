using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Interfaces.Services;
using Posting.Infrastructure.Contexts;
using Posting.Infrastructure.Handlers.Posts;
using Posting.Infrastructure.Repositories;
using Posting.Infrastructure.Services;
using System.Data;
using System.Data.Common;

namespace Posting.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Setting up Entity Framework Database Context, We are both setting the database connection and
            // the migration output project to the infrastructure project because that project is the one
            // responsible to have all our database technical settings.
            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("posting-service-db"),
                output => output.MigrationsAssembly("Posting.Infrastructure")));

            // Here we are setting up the connection string for the database to be used through DI without
            // the need to instance IConfiguration, with this we can use Dapper to make direct queries to our DB.
            builder.Services.AddScoped<IDbConnection>(sp =>
            {
                var connectionString = builder.Configuration.GetConnectionString("posting-service-db");
                return new NpgsqlConnection(connectionString);
            });

            // Injecting our interfaces and concrete class services to be used with DI
            // (Inversion of Control Concept, "I" of the SOLID Concepts)
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();

            builder.Services.AddScoped<IRepostRepository, RepostRepository>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Setting up and injecting our MediatR service, so we can actually use our handlers through the controllers.
            // Similar to the usual interface and concrete classes injection, but with handlers.
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLatestFeedHandler).Assembly));

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

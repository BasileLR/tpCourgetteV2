
using Microsoft.Extensions.Options;

namespace tpCourgetteV2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

                    => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=TpCourgette;User=blizzard2;Password=blizzard2;TrustServerCertificate=True;");

            {
                "Logging": {
                    "LogLevel": {
                        "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
                    }
                },
  "AllowedHosts": "*"
}

            // Add services to the container.

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

        builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "ToDo API",
Description = "An ASP.NET Core Web API for managing ToDo items",
TermsOfService = new Uri("https://example.com/terms"), Contact = new
OpenApiContact { Name = "Example Contact", Url = new
Uri("https://example.com/contact") }, License = new OpenApiLicense { Name =
"Example License", Url = new Uri("https://example.com/license") } });
});
    }
}

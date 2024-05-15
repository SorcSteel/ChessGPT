using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ChessGPT.BL;
using ChessGPT.BL.Services;
using ChessGPT.PL.Data;
using KB.ChessGPT.API.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


            
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<OpenAIConfig>(builder.Configuration.GetSection("OpenAI"));

            builder.Services.AddSignalR()
                        .AddJsonProtocol(options =>
                        {
                            options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                        });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ChessGPT API",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kaiden Brunke and Logan Vang",
                        Email = "700233885@fvtc.edu and logan.vang1348@fvtc.edu",
                        Url = new Uri("https://www.fvtc.edu")
                    }

                });

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                c.IncludeXmlComments(xmlpath);

            });

            builder.Services.AddScoped<IOpenAIService, OpenAIService>();

            //add conection information
            builder.Services.AddDbContextPool<ChessGPTEntities>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
                options.UseLazyLoadingProxies();
            });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.WithOrigins()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });

        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            //app.MapControllers();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChessGPTHub>("/chessgpthub");
            });

            app.Run();

    }
    public static async Task<string> GetSecret(string secretName)
    {
        try
        {
            //const string secretName = "DVDCentral-ConnectionString";
            var keyVaultName = "kv-500201348";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            //using var client = GetClient();
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine(secret.Value.Value.ToString());
            return secret.Value.Value.ToString();
            //return (await client.GetSecretAsync(kvUri, secretName)).Value.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

}
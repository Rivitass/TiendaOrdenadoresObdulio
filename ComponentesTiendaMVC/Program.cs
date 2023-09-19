using Azure.Storage.Blobs;
using ComponentesTiendaMVC.CrossCuting.Logging;
using ComponentesTiendaMVC.Data;
using ComponentesTiendaMVC.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using Polly;
using Polly.Extensions.Http;

namespace ComponentesTiendaMVC;

public class Program
{
	public static void Main(string[] args)
	{
        //ProcessAsync().GetAwaiter().GetResult();
        var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
		logger.Debug("init main");

		var builder = WebApplication.CreateBuilder(args);

		LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
		builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

		builder.Services.AddSingleton<IRepositorioComponente, RepositorioComponenteAPI>();
		builder.Services.AddSingleton<IRepositorioOrdenadores, RepositorioOrdenadorApi>();

		//builder.Services.AddScoped<IRepositorioComponente, EFRepositorioComponente>();
		//builder.Services.AddScoped<IRepositorioOrdenadores, EFRepositorioOrdenadores>();





		builder.Services.AddHttpClient("MyHttpClient")
			.AddPolicyHandler(GetCircuitBreakerPolicy());


		// Add services to the container.
		builder.Services.AddControllersWithViews();

		string path = Directory.GetCurrentDirectory();

		builder.Services.AddDbContext<OrdenadoresContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("Default")
				?.Replace("[DataDirectory]", path)));


		var app = builder.Build();

		//using (var scope = app.Services.CreateScope())
		//{
		//    var services = scope.ServiceProvider;

		//    var context = services.GetRequiredService<OrdenadoresContext>();
		//    context.Database.EnsureCreated();
		//    ComponenteDbInitializer.Initialize(context);
		//}

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Componente}/{action=Home}/{id?}");

		app.Run();

	}
	private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
	{
		return HttpPolicyExtensions
			.HandleTransientHttpError()
			.CircuitBreakerAsync(
				handledEventsAllowedBeforeBreaking: 3,
				durationOfBreak: TimeSpan.FromSeconds(30)
			);
	}


    //static async Task ProcessAsync()
    //{
    //    string containerName = "tiendaordenadores"; // Reemplaza con el nombre de tu contenedor
    //    string localFolderPath = "prueba";
    //    // Copy the connection string from the portal in the variable below.
    //    string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=almacenamiento2023091401;AccountKey=jBEoDwfpRy+aCglBQPqtshFCQSFwWNRsiH6ylM6kLHvfwGJdk9DqYKKyJwdI0JMAFSFUVkOEA6BI+AStwQZSLw==;EndpointSuffix=core.windows.net";

    //    // Create a client that can authenticate with a connection string
    //    BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);
    //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

    //    Console.WriteLine("Subiendo archivos a Azure Blob Storage...");

    //    // Lista todos los archivos en la carpeta local
    //    string[] files = Directory.GetFiles(localFolderPath);

    //    foreach (string filePath in files)
    //    {
    //        string blobName = "Logs/" + Path.GetFileName(filePath); // Directorio + nombre de archivo en Azure

    //        // Abre el archivo local
    //        using (FileStream fileStream = File.OpenRead(filePath))
    //        {
    //            // Sube el archivo a Azure Blob Storage
    //            BlobClient blobClient = containerClient.GetBlobClient(blobName);
    //            await blobClient.UploadAsync(fileStream, true);
    //            fileStream.Close();
    //        }

    //        Console.WriteLine($"Archivo {Path.GetFileName(filePath)} subido.");
    //    }

    //    Console.WriteLine("Todos los archivos han sido subidos a Azure Blob Storage.");

    //}
}


using ComponentesTiendaMVC.Models;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;

namespace ComponentesTiendaMVC.Services
{
	public class RepositorioComponenteAPI : IRepositorioComponente
	{

		private readonly HttpClient _httpClient;
        public const string urlbase = "https://tiendaordenadoresobdulio.azurewebsites.net/api/componente";
        public RepositorioComponenteAPI(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("MyHttpClient");
		}

		public void ActualizaComponente(Componente componente)
		{
			var url = urlbase + $"/{componente.Id}"; 
			var json = JsonConvert.SerializeObject(componente);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			
			var response = _httpClient.PutAsync(url, content).Result;

		
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Componente actualizado correctamente.");
			}
			else
			{
				
				Console.WriteLine($"Error al actualizar el componente. Código de estado: {response.StatusCode}");
			}
		}


		public void AddComponente(Componente componente)
		{
			var url = urlbase;
			var json = JsonConvert.SerializeObject(componente);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			_httpClient.PostAsync(url, content);
		}

		public void BorraComponente(int Id)
		{
			var url = urlbase + $"/{Id}";
			_httpClient.DeleteAsync(url);
		}

		public List<Componente>? ListaComponentes()
		{
			var url = urlbase;
			var callResponse = _httpClient.GetAsync(url).Result;
			var response = callResponse.Content.ReadAsStringAsync().Result;
			var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
			if (lista == null) return new();

			return lista;
		}

		public Componente? TomaComponente(int Id)
		{
			var url = urlbase + $"/{ Id}";
			var callResponse = _httpClient.GetAsync(url).Result;
			var response = callResponse.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<Componente>(response);
		}
	}
}

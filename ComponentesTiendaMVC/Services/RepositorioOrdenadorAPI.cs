using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ComponentesTiendaMVC.Models;
using Newtonsoft.Json;

namespace ComponentesTiendaMVC.Services
{
	public class RepositorioOrdenadorApi : IRepositorioOrdenadores
	{
		private readonly HttpClient _httpClient;
        public const string urlbase = "https://tiendaordenadoresobdulio.azurewebsites.net/api/ordenadores";
        public RepositorioOrdenadorApi(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("MyHttpClient");
		}

		public void AddOrdenador(Ordenador ordenador)
		{
			var url = urlbase;
			var json = JsonConvert.SerializeObject(ordenador);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			_httpClient.PostAsync(url, content).Wait();
		}

		public void BorraOrdenador(int Id)
		{
			var url = urlbase + $"/{Id}";
			_httpClient.DeleteAsync(url).Wait();
		}

		public void EditOrdenador(Ordenador ordenador)
		{
			var url = $"http://localhost:5117/api/Componente/{ordenador.IdOrdenador}";
			var json = JsonConvert.SerializeObject($"{ordenador.IdOrdenador},{ordenador}");
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

		public List<Ordenador> ListaOrdenadores()
		{
			var url = urlbase;
			var callResponse = _httpClient.GetAsync(url).Result;
			var response = callResponse.Content.ReadAsStringAsync().Result;
			var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
			if (lista == null) return new List<Ordenador>();

			return lista;
		}

        public List<Componente> ObtenerComponentesPorOrdenador(int id)
        {
            try
            {
                var url = $"http://localhost:5117/api/Ordenadores/componentes/{id}";
                var callResponse = _httpClient.GetAsync(url).Result;

                if (callResponse.IsSuccessStatusCode)
                {
                    var response = callResponse.Content.ReadAsStringAsync().Result;
                    var lista = JsonConvert.DeserializeObject<List<Componente>>(response);

                    if (lista == null)
                    {
                        return new List<Componente>();
                    }

                    return lista;
                }
                else
                {
                    
                    Console.WriteLine($"Error al obtener componentes por ordenador. Código de estado: {callResponse.StatusCode}");
                    return new List<Componente>();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error al obtener componentes por ordenador: {ex.Message}");
                throw;
            }
        }


        public Componente TomaComponente(int id)
		{
			var url = urlbase + $"/{id}";
			var callResponse = _httpClient.GetAsync(url).Result;
			var response = callResponse.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<Componente>(response);
		}

		public Ordenador TomaOrdenador(int Id)
		{
			var url = urlbase + $"/{Id}";
			var callResponse = _httpClient.GetAsync(url).Result;
			var response = callResponse.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<Ordenador>(response);
		}
	}
}

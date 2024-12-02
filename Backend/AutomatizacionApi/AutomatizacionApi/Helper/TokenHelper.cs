using System.Net.Http.Headers;
using System.Text.Json;

namespace AutomatizacionApi.NewFolder
{
    public class TokenHelper
    {
        private readonly HttpClient _httpClient;

        public TokenHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> SendRequestAsync<T>(string url, string token, HttpMethod method, object? body = null)
        {
            var request = new HttpRequestMessage(method, url);

            // Agregar el token al encabezado de autorización
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Si hay un cuerpo para la solicitud, lo serializamos a JSON
            if (body != null)
            {
                var json = JsonSerializer.Serialize(body);
                request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            }

            // Realizamos la solicitud
            var response = await _httpClient.SendAsync(request);

            // Lanza excepción si el código de respuesta no es exitoso
            response.EnsureSuccessStatusCode();

            // Leer y deserializar la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent);
        }
    }
}

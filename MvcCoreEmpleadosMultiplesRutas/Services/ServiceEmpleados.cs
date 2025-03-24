using NugetApiModelsCPC;
using System.Net.Http.Headers;

namespace MvcCoreEmpleadosMultiplesRutas.Services
{
    public class ServiceEmpleados
    {
        private string ApiUrl;

        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<Empleado> data = await response.Content.ReadAsAsync<List<Empleado>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/oficios";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<string> data = await response.Content.ReadAsAsync<List<string>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

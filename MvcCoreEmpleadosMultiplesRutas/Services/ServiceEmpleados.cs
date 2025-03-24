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

        private async Task<T> CallApisAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados";
                List<Empleado> data = await this.CallApisAsync<List<Empleado>>(request);
                return data;
               
            }
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Empleados/Oficios";
                List<string> data = await this.CallApisAsync<List<string>>(request);
                return data;
            }
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            string request = "api/empleados/empleadosoficio/" + oficio;
            List<Empleado> empleados = await this.CallApisAsync<List<Empleado>>(request);
            return empleados;
        }
    }
}

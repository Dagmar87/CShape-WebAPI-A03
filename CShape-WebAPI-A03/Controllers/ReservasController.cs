using CShape_WebAPI_A03.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CShape_WebAPI_A03.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string apiUrl = "https://localhost:44311/api/reservas";

        public async Task<IActionResult> Index()
        {
            List<Reserva> listaReservas = new List<Reserva>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResponse);
                }
            }

            return View(listaReservas);
        }
    }
}

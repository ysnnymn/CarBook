using CarBook.Dto.CarPricngDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarPricngController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CarPricngController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async  Task<IActionResult> Index()
        {
            
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7239/api/CarPricings/GetCarPricingWithTimePeriodList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}

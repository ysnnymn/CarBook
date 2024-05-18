using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task< IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7239/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach (var item in resultCarFeatureByCarIdDtos)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7239/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7239/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
               

            }
            return RedirectToAction("Index", "AdminCar");
        }
        [Route("CarFeatureByCarId")]
        [HttpGet]
        public async Task<IActionResult> CarFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7239/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        
    }
}

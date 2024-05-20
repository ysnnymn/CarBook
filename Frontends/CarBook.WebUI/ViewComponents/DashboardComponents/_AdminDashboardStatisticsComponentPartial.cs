using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData);
                ViewBag.carcount = values.carCount;


            }
            #endregion


            #region LocationCount
            var responseMessage1 = await client.GetAsync("https://localhost:7239/api/Statistics/GetLocationCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData1);
                ViewBag.locationcount = values1.locationCount;


            }
            #endregion
            
           

            #region BrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7239/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;


            }
            #endregion


            #region RentPriceOrDaily
            var responseMessage6 = await client.GetAsync("https://localhost:7239/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData6);
                ViewBag.avgPriceForDaily = values6.avgPriceForDaily.ToString("0,00");


            }
            #endregion

           


            return View();
        }
    }
}

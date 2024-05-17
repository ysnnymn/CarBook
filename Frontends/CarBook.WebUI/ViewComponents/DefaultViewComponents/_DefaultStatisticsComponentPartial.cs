using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region CarCount
           
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
            #region carCountByFuelElectiric
            var responseMessage16 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByFuelElectiric");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData16);
                ViewBag.carCountByFuelElectiric = values16.carCountByFuelElectiric;


            }
            #endregion
            return View();
        }
    }
}

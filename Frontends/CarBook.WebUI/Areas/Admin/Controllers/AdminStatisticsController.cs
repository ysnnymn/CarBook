using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
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
            #region AuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7239/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage1.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData3);
                ViewBag.authorcount = values3.locationCount;


            }
            #endregion
            #region BlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7239/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData4);
                ViewBag.blogcount = values4.blogCount;


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
            #region RentPriceOrMountlhy
            var responseMessage7 = await client.GetAsync("https://localhost:7239/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("0,00");


            }
            #endregion
            #region RentPriceOrWeekly
            var responseMessage8 = await client.GetAsync("https://localhost:7239/api/Statistics/GetAvgRentPriceForMounthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData8);
                ViewBag.avgRentPriceForMounthly = values8.avgRentPriceForMounthly.ToString("0,00");


            }
            #endregion


            #region carCountByTransmassionIsAuto
            var responseMessage9 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByTransmassionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData9);
                ViewBag.carCountByTransmassionIsAuto = values9.carCountByTransmassionIsAuto;


            }
            #endregion

            #region brandNameByMaxCar
            var responseMessage17 = await client.GetAsync("https://localhost:7239/api/Statistics/BrandNameByMaxCar");
            if (responseMessage17.IsSuccessStatusCode)
            {
                var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();
                var values17 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData17);
                ViewBag.brandNameByMaxCar = values17.brandNameByMaxCar;


            }
            #endregion
            #region blogTitleByMaxBlogComment
            var responseMessagea = await client.GetAsync("https://localhost:7239/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessagea.IsSuccessStatusCode)
            {
                var jsonData1a = await responseMessagea.Content.ReadAsStringAsync();
                var valuesa = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData1a);
                ViewBag.blogTitleByMaxBlogComment = valuesa.blogTitleByMaxBlogComment;


            }
            #endregion

            #region carCountByKmSmallerThen1000
            var responseMessage10 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData10);
                ViewBag.carCountByKmSmallerThen1000 = values10.carCountByKmSmallerThen1000;


            }
            #endregion




            #region carCountByFuelGasolineOrDiesel
            var responseMessage15 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData15);
                ViewBag.carCountByFuelGasolineOrDiesel = values15.carCountByFuelGasolineOrDiesel;


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
            #region    carBrandAndModelByRentPriceMaxroperty
            var responseMessage13 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarBrandAndModelByRentPriceMax");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData13);
                ViewBag.carBrandAndModelByRentPriceMaxroperty = values13.carBrandAndModelByRentPriceMaxroperty;


            }
            #endregion
            #region    carBrandAndModelByRentPriceMin
            var responseMessage14 = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarBrandAndModelByRentPriceMin");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisctsDto>(jsonData14);
                ViewBag.carBrandAndModelByRentPriceMin = values14.carBrandAndModelByRentPriceMin;


            }
            #endregion

            
            return View();
        }

    }
}

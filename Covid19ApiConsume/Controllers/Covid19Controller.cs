using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Covid19ApiConsume.Models;
using Newtonsoft.Json;


namespace Covid19ApiConsume.Controllers
{
    public class Covid19Controller : Controller
    {
        // GET: Covid19
        public ActionResult Index()
        {
           var covid19 = new Covid19ViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.covid19api.com/");

                var response =
                    client.GetAsync("summary?fbclid=IwAR0OKbr_6W79uEpZ5HExsnOie2NdJCu7hSev_JQgYV4SM5KiM9A5LVCTyDs").Result;
                    

                
                if (response.IsSuccessStatusCode)
                {

                   covid19 = response.Content.ReadAsAsync<Covid19ViewModel>().Result;             // install-package Microsoft.AspNet.WebApi.Client is needed for ReadAsAsync<>


                }
                else
                {
                    ViewBag.Message = " server error";
                }
            }

            return View(covid19);
        }
    }
}


  
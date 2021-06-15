using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http; 
using ActioItemWebAPI.Models;
using System.Net;
using Newtonsoft.Json;

namespace ActioItemWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        private NumberDBEntities context = new NumberDBEntities();
        //public IEnumerable <SequenceModel> Get ()
        //{
        //    IEnumerable<SequenceModel> list = null; 

        //    list = (from c in context.Series select new SequenceModel)
        //}

        public ActionResult GetJsonDataModel()
        {
            foreach (var itm in Model)
            {
                var webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.Cookie, "cookievalue");
                var json = webClient.DownloadString(@"https://jsonplaceholder.typicode.com/todos/1");
                Models.NumberDBEntities objJson = JsonConvert.DeserializeObject<Models.NumberDBEntities>(json);
                return View("Index", objJson);
            }
        }
    }
}

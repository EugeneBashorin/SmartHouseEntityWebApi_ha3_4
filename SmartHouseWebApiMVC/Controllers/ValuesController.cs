using MVCSmartHouse.ViewModels.AdaptModels;
using Newtonsoft.Json.Linq;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SmartHouseWebApiMVC.Controllers
{
    public class ValuesController : ApiController
    {
        public NewHeater[] newDev;

        public IEnumerable<NewHeater> SaveDev(NewHeater newStateDev)
        {
            newDev = new NewHeater[] { newStateDev };
            return newDev;
            
        }

        [Route("api/values/OnState")]
        public JsonResult<NewHeater> PutStateOn([FromBody] JObject model)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOn();
            SaveDev(device);
            return Json(device);
        }

        [Route("api/values/OffState")]
        public JsonResult<NewHeater> PutStateOff([FromBody] JObject model)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOff();
            return Json(device);
        }

        [Route("api/values/IncTemp")]
        public JsonResult<NewHeater> PutIncTemp([FromBody] JObject model)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOn();
            device?.IncreaseTemperature();
            return Json(device);
        }

        [Route("api/values/DecTemp")]
        public JsonResult<NewHeater> PutDecTemp([FromBody] JObject model)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOn();
            device?.DecreaseTemperature();
            return Json(device);
        }

        [Route("api/values/SetTemp/{value}")]
        public JsonResult<NewHeater> PutSetTemp([FromBody] JObject model, int value)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOn();
            device?.HandSetTemperature(value);
            return Json(device);
        }

        [Route("api/values/SetMode/{value}")]
        public JsonResult<NewHeater> PutSetMode([FromBody] JObject model, string value)
        {
            var device = model.ToObject<NewHeater>();
            device?.SwtchOn();
            if (value == "Turbo")
            {
                device.SetMaxMode();
            }
            else if (value == "Eco")
            {
                device.SetMiddleMode();
            }
            else if (value == "Low")
            {
                device.SetMinMode();
            }
            else
            {
                device.SetAutoMode();
            }
            return Json(device);
        }

    }
}

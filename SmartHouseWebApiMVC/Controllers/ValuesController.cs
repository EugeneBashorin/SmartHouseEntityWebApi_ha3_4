using MVCSmartHouse.ViewModels.AdaptInterfacies;
using Newtonsoft.Json.Linq;
using SimpleSmartHouse1._0;
using SmartHouseWebApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
//using System.Web.Mvc;

namespace SmartHouseWebApiMVC.Controllers
{
    public class ValuesController : ApiController
    {
        private DeviceContext db = new DeviceContext();

        [Route("api/values/{id}/{command}")]
        public string PutSwitchFunc(int id, string command)
        {
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                switch (command)
                {
                    case "on":
                        device.SwtchOn();
                        break;
                    case "off":
                        device.SwtchOff();
                        break;
                    case "IncTemp":
                        ((ITemperatureAble)device).IncreaseTemperature();
                        break;
                    case "DecTemp":
                        ((ITemperatureAble)device).DecreaseTemperature();
                        break;
                }
                db.Entry(device).State = EntityState.Modified;
            }
            db.SaveChanges();
            return "Device: " + device.Name + "<br/>" + device.ToString();
        }

        [Route("api/values/SetBright/{value}")]
        public string PutSetBright(int? id, string value)
        {
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                switch (value)
                {
                    case "BrightWhite":
                        ((IlluminatorModeAble)device).SetMaxMode();
                        break;
                    case "DayLight":
                        ((IlluminatorModeAble)device).SetMiddleMode();
                        break;
                    case "WarmWhite":
                        ((IlluminatorModeAble)device).SetMinMode();
                        break;
                    default:
                        ((IlluminatorModeAble)device).SetAutoMode();
                        break;
                }
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return "Device: " + device.Name + "<br/>" + device.ToString();
        }

        //Set temp Heater
        [Route("api/values/{id}/{command}/{value}")]
        public string PutSetParam(int id, string command, int value)
        {
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                switch (command)
                {
                    case "heatTemp":
                        ((IHandSetTempWarmAble)device).HandSetTemperature(value);
                        break;
                    case "coldTemp":
                        ((IHandSetTempColdAble)device).HandSetTemperature(value);
                        break;
                }
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return "Device: " + device.Name + "<br/>" + device.ToString();
        }

        //[Route("api/values/{id}/{command}")]
        //public HttpResponseMessage PutSwitchFunc(int id, string command)
        //{
        //    Device device = db.Devices.Find(id);
        //    if (device != null)
        //    {
        //        switch (command)
        //        {
        //            case "on":
        //                device.SwtchOn();
        //                break;
        //            case "off":
        //                device.SwtchOff();
        //                break;
        //            case "IncTemp":
        //                ((ITemperatureAble)device).IncreaseTemperature();
        //                break;
        //            case "DecTemp":
        //                ((ITemperatureAble)device).DecreaseTemperature();
        //                break;
        //        }
        //    }
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return Request.CreateResponse(HttpStatusCode.OK, device);
        //}



        //[Route("api/values/{id}/{command}/{value}")]
        //public HttpResponseMessage PutSetParam(int id, string command, int value)
        //{
        //    Device device = db.Devices.Find(id);
        //    if (device != null)
        //    {
        //        switch (command)
        //        {
        //            case "heatTemp":
        //                ((IHandSetTempWarmAble)device).HandSetTemperature(value);
        //                break;
        //            case "coldTemp":
        //                ((IHandSetTempColdAble)device).HandSetTemperature(value);
        //                break;
        //        }
        //    }
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return Request.CreateResponse(HttpStatusCode.OK, device);
        //}


        [Route("api/values/SetMode/{value}")]
        public HttpResponseMessage PutSetMode(int? id, string value)
        {
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                switch (value)
                {
                    case "Turbo":
                        ((IColdModeAble)device).SetMaxMode();
                        break;
                    case "Eco":
                        ((IColdModeAble)device).SetMiddleMode();
                        break;
                    case "Low":
                        ((IColdModeAble)device).SetMinMode();
                        break;
                    default:
                        ((IColdModeAble)device).SetAutoMode();
                        break;
                }
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, device);
        }


        //[Route("api/values/SetBright/{value}")]
        //public HttpResponseMessage PutSetBright(int? id, string value)
        //{
        //    Device device = db.Devices.Find(id);
        //    if (device != null)
        //    {
        //        switch (value)
        //        {
        //            case "BrightWhite":
        //                ((IlluminatorModeAble)device).SetMaxMode();
        //                break;
        //            case "DayLight":
        //                ((IlluminatorModeAble)device).SetMiddleMode();
        //                break;
        //            case "WarmWhite":
        //                ((IlluminatorModeAble)device).SetMinMode();
        //                break;
        //            default:
        //                ((IlluminatorModeAble)device).SetAutoMode();
        //                break;
        //        }
        //    }
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return Request.CreateResponse(HttpStatusCode.OK, device);
        //}


        [HttpDelete]
        [Route("api/values/Delete/{id}")]
        public void Delete(int? id)
        {
                Device device = db.Devices.Find(id);
            if (device != null)
            {
                db.Devices.Remove(device);
                }
            db.SaveChanges();

        }


        protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }

    }
}

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

        [Route("api/values/SetBright/{id}/{value}")]
        public string PutSetBright(int? id, string value)
        {
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                if (device is IlluminatorModeAble)
                {
                    switch (value)
                    {
                        case "BrightWhite":
                            ((IlluminatorModeAble)device).SetMaxMode();
                            break;
                        case "Daylight":
                            ((IlluminatorModeAble)device).SetMiddleMode();
                            break;
                        case "WarmWhite":
                            ((IlluminatorModeAble)device).SetMinMode();
                            break;
                        case "Default":
                            ((IlluminatorModeAble)device).SetAutoMode();
                            break;
                    }
                }
                else if (device is IWarmModeAble)
                {
                    switch (value)
                    {
                        case "Turbo":
                            ((IWarmModeAble)device).SetMaxMode();
                            break;
                        case "Eco":
                            ((IWarmModeAble)device).SetMiddleMode();
                            break;
                        case "Low":
                            ((IWarmModeAble)device).SetMinMode();
                            break;
                        default:
                            ((IWarmModeAble)device).SetAutoMode();
                            break;
                    }
                }
                else if (device is IColdModeAble)
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
                }
                db.Entry(device).State = EntityState.Modified;
            }
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

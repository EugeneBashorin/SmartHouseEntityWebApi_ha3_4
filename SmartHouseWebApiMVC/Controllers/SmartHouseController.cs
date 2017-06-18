using MVCSmartHouse.ViewModels.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SmartHouseWebApiMVC.Models;

namespace MVCSmartHouse.Controllers
{
    public class SmartHouseController : Controller
    {
        private DeviceContext db = new DeviceContext();

        public ActionResult Index()
        {
            SelectListItem[] deviceList = new SelectListItem[3];
            deviceList[0] = new SelectListItem { Text = "Heater", Value = "Heater" };
            deviceList[1] = new SelectListItem { Text = "AirCondition", Value = "AirCondition" };
            deviceList[2] = new SelectListItem { Text = "Illuminator", Value = "Illuminator" };
            ViewBag.DeviceList = deviceList;

            return View(db.Devices);
        }

         ////ADD
        public ActionResult Add(string device)
        {
            Device newDevice;
            switch (device)
            {
                case "Heater":
                    newDevice = new Heater("Heater", false, Mode.Eco, 18);
                    break;
                case "AirCondition":
                    newDevice = new AirCondition("AirCondition", false, Mode.Low, new Parametr(8, 15, 12));
                    break;
                case "Illuminator":
                    newDevice = new Illuminator("Illuminator", false, IlluminatorBrightness.Default);
                    break;
                default:
                    newDevice = new Illuminator("Illuminator", false, IlluminatorBrightness.Default);
                   break;
            }
            db.Devices.Add(newDevice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //SetBrightMode 
        public ActionResult SetIlluminatorBright(int? id, string ill)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Device device = db.Devices.Find(id);

            if (device == null)
            {
                return HttpNotFound();
            }
            IlluminatorModeAble illum = (IlluminatorModeAble)device;
            Session["illBright"] = ill;
            switch (ill)
            {
                case "BrightWhite":
                    illum.SetMaxMode();
                    break;
                case "Daylight":
                    illum.SetMiddleMode();
                    break;
                case "WarmWhite":
                    illum.SetMinMode();
                    break;
                default:
                    illum.SetAutoMode();
                    break;
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //SetMode
        public ActionResult SetWarmMode(int? id, string warmMode)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Device device = db.Devices.Find(id);

            if (device == null)
            {
                return HttpNotFound();
            }
            IWarmModeAble wMode = (IWarmModeAble)device;
            Session["wMode"] = warmMode;
            switch (warmMode)
            {
                case "Turbo":
                    wMode.SetMaxMode();
                    break;
                case "Eco":
                    wMode.SetMiddleMode();
                    break;
                case "Low":
                    wMode.SetMinMode();
                    break;
                default:
                    wMode.SetAutoMode();
                    break;
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SetColdMode(int? id, string coldMode)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Device device = db.Devices.Find(id);

            if (device == null)
            {
                return HttpNotFound();
            }
            IColdModeAble cMode = (IColdModeAble)device;
            Session["Mode"] = coldMode;
            switch (coldMode)
            {
                case "Turbo":
                    cMode.SetMaxMode();
                    break;
                case "Eco":
                    cMode.SetMiddleMode();
                    break;
                case "Low":
                    cMode.SetMinMode();
                    break;
                default:
                    cMode.SetAutoMode();
                    break;
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Partial for Illuminator
        public PartialViewResult RenderStateLamp(Illuminator model)
        {
         return PartialView("PartialLampView", model);
        }

        //Partial for Heater
        public PartialViewResult RenderStateHeater(Heater model)
        {
            return PartialView("PartialHeaterView", model);
        }

        //Partial for AirCondition
        public PartialViewResult RenderStateAC(AirCondition model)
        {
            return PartialView("PartialACView", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
         
        //WebApi

        //public ActionResult MainFunc(int? id, string command)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Device device = db.Devices.Find(id);

        //    if (device == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    if (device is Device)
        //    {
        //        if (device is ITemperatureAble)
        //        {
        //            temperat = (ITemperatureAble)device;
        //        }

        //        switch (command)
        //        {
        //            case "On":
        //                device.SwtchOn();
        //                break;
        //            case "Off":
        //                device.SwtchOff();
        //                break;
        //            case "IncTemp":
        //                temperat.IncreaseTemperature();
        //                break;
        //            case "DecTemp":
        //                temperat.DecreaseTemperature();
        //                break;
        //        }
        //    }
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //HandSetTemperatureHeater
        //public ActionResult SetHeatTemperature(int? id, int warmTemper = 15)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Device device = db.Devices.Find(id);

        //    if (device == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ((IHandSetTempWarmAble)device).HandSetTemperature(warmTemper);
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //HandSetTemperatureAC
        //public ActionResult SetColdTemperature(int? id, int coldTemper = 15)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Device device = db.Devices.Find(id);

        //    if (device == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ((IHandSetTempColdAble)device).HandSetTemperature(coldTemper);
        //    db.Entry(device).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Device device = db.Devices.Find(id);

        //    if (device == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.Devices.Remove(device);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
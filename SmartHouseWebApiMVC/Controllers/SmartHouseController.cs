using MVCSmartHouse.ViewModels.AdaptInterfacies;
using MVCSmartHouse.ViewModels.AdaptModels;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSmartHouse.Controllers
{
    public class SmartHouseController : Controller
    {
        IVolumeAble vol;
        IChannelAble ch;
        ISetChannelAble chList;
        ITemperatureAble temperat;

        public ActionResult Index()
        {
            IDictionary<int, Device> deviceDictionary;

            if (Session["Device"] == null)
            {
                deviceDictionary = new SortedDictionary<int, Device>();
                deviceDictionary.Add(1, new NewTV("TV", false, new Parametr(1, 50, 3), new Parametr(1, 45, 12), new ChangeSetting(), BrightnessLevel.Default, new ListFunction()));
                deviceDictionary.Add(2, new NewRadio("Radio", false, new Parametr(1, 13, 3), new Parametr(1, 45, 10), new ChangeSetting(), new ListFunction()));
                deviceDictionary.Add(3, new NewHeater("Heater", false, Mode.Eco, new Parametr(15, 34, 18), new ChangeSetting()));
                deviceDictionary.Add(4, new NewAirCondition("AirCondition", false, Mode.Low, new Parametr(8, 26, 18), new ChangeSetting()));
                deviceDictionary.Add(5, new NewIlluminator("Illuminator", false, IlluminatorBrightness.Default));
                Session["Device"] = deviceDictionary;
                Session["NextId"] = 6;
            }
            else
            {
                deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            }
            SelectListItem[] deviceList = new SelectListItem[5];
            deviceList[0] = new SelectListItem { Text = "TV", Value = "TV", Selected = true };
            deviceList[1] = new SelectListItem { Text = "Radio", Value = "Radio" };
            deviceList[2] = new SelectListItem { Text = "Heater", Value = "Heater" };
            deviceList[3] = new SelectListItem { Text = "AirCodition", Value = "AirCodition" };
            deviceList[4] = new SelectListItem { Text = "Illuminator", Value = "Illuminator" };
            ViewBag.DeviceList = deviceList;
            return View(deviceDictionary);
        }

        //ADD
        public ActionResult Add(string device)
        {
            Device newDevice;
            switch (device)
            {
                default:
                    newDevice = new NewTV("TV", false, new Parametr(1, 50, 3), new Parametr(1, 45, 15), new ChangeSetting(), BrightnessLevel.Default, new ListFunction());
                    break;
                case "Radio":
                    newDevice = new NewRadio("Radio", false, new Parametr(1, 13, 3), new Parametr(1, 45, 15), new ChangeSetting(), new ListFunction());
                    break;
                case "Heater":
                    newDevice = new NewHeater("Heater", false, Mode.Eco, new Parametr(8, 15, 12), new ChangeSetting());
                    break;
                case "AirCondition":
                    newDevice = new NewAirCondition("AirCondition", false, Mode.Low, new Parametr(8, 15, 12), new ChangeSetting());
                    break;
                case "Illuminator":
                    newDevice = new NewIlluminator("Illuminator", false, IlluminatorBrightness.Default);
                    break;
            }
            int id = (int)Session["NextId"];
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            deviceDictionary.Add(id, newDevice);
            id++;
            Session["NextId"] = id;
            return RedirectToAction("Index");
        }

        public ActionResult MainFunc(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is Device)
            {
                if (deviceDictionary[id] is IVolumeAble)
                {
                    vol = (IVolumeAble)deviceDictionary[id];//inc decr VOLUME
                }
                if (deviceDictionary[id] is IChannelAble)
                {
                    ch = (IChannelAble)deviceDictionary[id];//inc decr CHANNEL
                }
                if (deviceDictionary[id] is ISetChannelAble)
                {
                    chList = (ISetChannelAble)deviceDictionary[id];//Load Show  CHAN_LIst  HIDE_LIst 
                }
                if (deviceDictionary[id] is ITemperatureAble)
                {
                    temperat = (ITemperatureAble)deviceDictionary[id];// inc decr TEMPERATURE
                }

                switch (command)
                {
                    case "On":
                        deviceDictionary[id].SwtchOn();
                        break;
                    case "Off":
                        deviceDictionary[id].SwtchOff();
                        break;
                    case "Del":
                        deviceDictionary.Remove(id);
                        break;
                    case "IncVol":
                        vol.IncreaseVolume();
                        break;
                    case "DecVol":
                        vol.DecreaseVolume();
                        break;
                    case "IncCh":
                        ch.IncreaseChannel();
                        break;
                    case "DecCh":
                        ch.DecreaseChannel();
                        break;
                    case "LoadChan":
                        chList.LoadChannel();
                        break;
                    case "ShowChan":
                        if (deviceDictionary[id].State)
                        {
                            if (deviceDictionary[id] is NewTV)
                            {
                                Session["TVList"] = chList.ShowChannelList();
                            }
                            if (deviceDictionary[id] is NewRadio)
                            {
                                Session["RadioList"] = chList.ShowChannelList();
                            }
                        }
                        break;
                    case "HideChan":
                        if (chList is NewTV)
                        {
                            Session["TVList"] = null;
                        }
                        if (chList is NewRadio)
                        {
                            Session["RadioList"] = null;
                        }
                        break;
                    case "IncTemp":
                        temperat.IncreaseTemperature();
                        break;
                    case "DecTemp":
                        temperat.DecreaseTemperature();
                        break;
                }
            }
            return RedirectToAction("Index");
        }

        //HandSetTemperatureHeater
        public ActionResult SetHeatTemperature(int id, int warmTemper = 15)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetTempWarmAble)deviceDictionary[id]).HandSetTemperature(warmTemper);
            return RedirectToAction("Index");
        }
        //HandSetTemperatureAC
        public ActionResult SetColdTemperature(int id, int coldTemper = 15)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetTempColdAble)deviceDictionary[id]).HandSetTemperature(coldTemper);
            return RedirectToAction("Index");
        }

        //HandSetVolume
        public ActionResult SetTVVolume(int id, int tvVolume = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetTVVolumeAble)deviceDictionary[id]).HandSetVolume(tvVolume);
            return RedirectToAction("Index");
        }

        public ActionResult SetRadioVolume(int id, int rVolume = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetRadioVolumeAble)deviceDictionary[id]).HandSetVolume(rVolume);
            return RedirectToAction("Index");
        }

        //HandSetChannelForTV
        public ActionResult SetTVChannel(int id, int tvChannel = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetTVChannelAble)deviceDictionary[id]).HandSetChannel(tvChannel);
            return RedirectToAction("Index");
        }

        //HandSetChannelForRadio
        public ActionResult SetRadioChannel(int id, int rChannel = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            ((IHandSetRadioChannelAble)deviceDictionary[id]).HandSetChannel(rChannel);
            return RedirectToAction("Index");
        }

        //SetBrightMode 
        public ActionResult SetBrightMode(int id, string brightMode)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            IMultimediaBrightAble bMode = (IMultimediaBrightAble)deviceDictionary[id];
            Session["BrightMode"] = brightMode;
            switch (brightMode)
            {
                case "Bright":
                    bMode.SetMaxMode();
                    break;
                case "Medium":
                    bMode.SetMiddleMode();
                    break;
                case "Low":
                    bMode.SetMinMode();
                    break;
                default:
                    bMode.SetAutoMode();
                    break;
            }
            return RedirectToAction("Index");
        }

        //SetBrightMode 
        public ActionResult SetIlluminatorBright(int id, string ill)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            IlluminatorModeAble illum = (IlluminatorModeAble)deviceDictionary[id];
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
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        //SetMode
        public ActionResult SetWarmMode(int id, string warmMode)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            IWarmModeAble wMode = (IWarmModeAble)deviceDictionary[id];
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
            return RedirectToAction("Index");
        }

        public ActionResult SetColdMode(int id, string coldMode)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            IColdModeAble cMode = (IColdModeAble)deviceDictionary[id];
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
            return RedirectToAction("Index");
        }

        public ActionResult RenderState(NewHeater model)
        {
            return PartialView("PartialHeaterView", model);
        }
    }
}


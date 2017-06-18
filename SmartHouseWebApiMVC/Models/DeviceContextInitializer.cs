
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHouseWebApiMVC.Models
{
    public class DeviceContextInitializer : DropCreateDatabaseAlways<DeviceContext>
    {
        protected override void Seed(DeviceContext context)
        {
            Device heater = new Heater( "Heater", false, Mode.Eco,18 /* new Parametr(15, 34, 18)*//*, new ChangeSetting()*/);
            Device airCondition = new AirCondition( "AirCondition", false, Mode.Low, new Parametr(8, 26, 18)/*, new ChangeSetting()*/);
            Device Illuminator = new Illuminator("Illuminator", false, IlluminatorBrightness.Default);

            context.Devices.Add(heater);
            context.Devices.Add(airCondition);
            context.Devices.Add(Illuminator);

            context.SaveChanges();
        }
    }
}
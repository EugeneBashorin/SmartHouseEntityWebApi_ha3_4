using SimpleSmartHouse1._0;
using SmartHouseWebApiMVC.Models.Enums;
using SmartHouseWebApiMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebApiMVC.Models.DeviceClasses
{
   

    public class Fridge : Device//, IFreezeAble<FreezeMode>
    {
        public const int Max = 18;
        public const int Min = -26;
        public int current = 8;

        public int Temperature
        {
            get { return current; }
            set
            {
                if (Max < value)
                {
                    current = Max;
                }
                else if (Min > value)
                {
                    current = Min;
                }
                else
                {
                    current = value;
                }
            }
        }

        public FreezeMode FreezeLevel { get; set; }

        public bool lamp;

        public Fridge()
        { }
        public Fridge(string name, bool state, FreezeMode freezeLevel, int temperature, bool door) : base(name, state)
        {
            FreezeLevel = freezeLevel;
            Temperature = temperature;
        }



         public void IncreaseTemperature()
        {
            Temperature++;
            if(Temperature<15)
            {
                FreezeLevel = FreezeMode.Deep;
            }
        }

        public void DecreaseTemperature()
        {
            Temperature--;
        }

        public void HandSetTemperature(int inputData)
        {
            Temperature = inputData;
        }

        public void SetDeepMode()
        {
            FreezeLevel = FreezeMode.Deep;
        }

        public void SetMFrostMode()
        {
            FreezeLevel = FreezeMode.Frost;
        }

        public void SetNormalMode()
        {
            FreezeLevel = FreezeMode.Normal;
        }

        public void SetLowFrostMode()
        {
            FreezeLevel = FreezeMode.Low;
        }
        public void SetDefrostMode()
        {
            FreezeLevel = FreezeMode.Defrost;
        }

        public override string ToString()
        {
            string freezeLevel;
            string temperature;
            if (State)
            {
                if (this.FreezeLevel == FreezeMode.Deep)
                {
                    freezeLevel = "Deep";
                }
                else if (this.FreezeLevel == FreezeMode.Frost)
                {
                    freezeLevel = "Frost";
                }
                else if (this.FreezeLevel == FreezeMode.Low)
                {
                    freezeLevel = "Low";
                }
                else if (this.FreezeLevel == FreezeMode.Defrost)
                {
                    freezeLevel = "Defrost";
                }
                else
                {
                    freezeLevel = "Normal";
                }
                temperature = Temperature.ToString();
            }
            else
            {
                freezeLevel = "--";
                temperature = "--";
            }
            return base.ToString() + " Mode:" + freezeLevel + " Temperature:" + temperature;
        }
    }
}
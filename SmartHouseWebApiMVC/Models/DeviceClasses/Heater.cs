
using MVCSmartHouse.ViewModels.AdaptInterfacies;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleSmartHouse1._0
{
    [DataContract]
    public class Heater : Device, IModeDefaultSettingsAble, ITemperatureAble, IModeAble<Mode>, IHandSetTempWarmAble, IWarmModeAble, IIncDecTemperatureAble
    {
        public const int Max = 34;
        public const int Min = 15;
        public int current = 18;

        public int Current
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

        [DataMember]
        [Required]
        public Mode Mode { get; set; }

        [DataMember]
        [Required]
        public int Temperature
        {
            get { return Current; }
            set { Current = value; }
        }

        public Heater()
        { }
        public Heater(string name, bool state, Mode mode, int temperature) : base(name, state)
        {
            Mode = mode;
            Temperature = temperature;
        }

        public void IncreaseTemperature()
        {
            Temperature++;
        }

        public void DecreaseTemperature()
        {
            Temperature--;
        }

        public void HandSetTemperature(int inputData)
        {
            Temperature = inputData;
        }

        public void SetMaxMode()
        {
            Mode = Mode.Turbo;
        }

        public void SetMiddleMode()
        {
            Mode = Mode.Eco;
        }

        public void SetMinMode()
        {
            Mode = Mode.Low;
        }

        public void SetAutoMode()
        {
            Mode = Mode.Auto;
        }

        public override string ToString()
        {
            string mode;
            string temperature;
            if (State)
            {
                if (this.Mode == Mode.Turbo)
                {
                    mode = "Turbo";
                }
                else if (this.Mode == Mode.Eco)
                {
                    mode = "Eco";
                }
                else if (this.Mode == Mode.Low)
                {
                    mode = "Low";
                }
                else
                {
                    mode = "Auto";
                }
                temperature = Temperature.ToString();
            }
            else
            {
                mode = "--";
                temperature = "--";
            }
            return base.ToString() + " Mode:" + mode + " Temperature:" + temperature;
        }
    }
}

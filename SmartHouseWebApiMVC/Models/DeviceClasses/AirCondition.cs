using MVCSmartHouse.ViewModels.AdaptInterfacies;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleSmartHouse1._0
{
    [DataContract]
   public class AirCondition : Device, IModeDefaultSettingsAble, ITemperatureAble, IModeAble<Mode>, IHandSetTempColdAble, IColdModeAble, IIncDecTemperatureAble
    {
        [DataMember]
        [Required]
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        private Mode mode;
        public IParametrAble TemperatureParam = new Parametr(8, 26, 18);

        [DataMember]
        [Required]
        public int Temperature
        {
            get { return TemperatureParam.Current; }
            set { TemperatureParam.Current = value; }
        }

        public AirCondition()
        { }

        public AirCondition( string name, bool state, Mode mode, IParametrAble temperatureParam) : base( name, state)
        {           
            this.mode = mode;
            TemperatureParam = temperatureParam;
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

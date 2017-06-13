namespace SimpleSmartHouse1._0
{
    class AirCondition : Device, IModeDefaultSettingsAble, ITemperatureAble, IModeAble<Mode>
    {
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private Mode mode;
        public IChangeSettingAble ChangeParams;
        public IParametrAble TemperatureParam;

        public int Temperature
        {
            get { return TemperatureParam.Current; }
            set { TemperatureParam.Current = value; }
        }
        public AirCondition(string name, bool state, Mode mode, IParametrAble temperatureParam, IChangeSettingAble сhangeParams) : base(name, state)
        {
            Name = name;
            State = state;
            this.mode = mode;
            TemperatureParam = temperatureParam;
            ChangeParams = сhangeParams;
        }
        public void IncreaseTemperature()
        {
            Temperature = ChangeParams.Increase(Temperature);
        }

        public void DecreaseTemperature()
        {
            Temperature = ChangeParams.Decrease(Temperature);
        }

        public void HandSetTemperature(int inputData)
        {
            Temperature = ChangeParams.HandSet(inputData);
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


using MVCSmartHouse.ViewModels.AdaptInterfacies;
using System.Runtime.Serialization;

namespace SimpleSmartHouse1._0
{
    [DataContract]
    public class Illuminator : Device, IModeDefaultSettingsAble, IBrightAble<IlluminatorBrightness>, IlluminatorModeAble
    {
        [DataMember]
        public IlluminatorBrightness Bright
        {
            get { return bright; }
            set { bright = value; }
        }
        private IlluminatorBrightness bright;

        public Illuminator()
        {  }

        public Illuminator(/*int id,*/ string name, bool state, IlluminatorBrightness bright) : base(/*id,*/ name, state)
        {
            this.bright = bright;
        }

        public void SetMaxMode()
        {
            Bright = IlluminatorBrightness.BrightWhite;
        }

        public void SetMiddleMode()
        {
            Bright = IlluminatorBrightness.Daylight;
        }

        public void SetMinMode()
        {
            Bright = IlluminatorBrightness.WarmWhite;
        }

        public void SetAutoMode()
        {
            Bright = IlluminatorBrightness.Default;
        }

        public override string ToString()
        {
            string bright;
            if (State)
            {
                if (this.Bright == IlluminatorBrightness.BrightWhite)
                    bright = "Bright White";
                else if (this.Bright == IlluminatorBrightness.Daylight)
                    bright = "Day light";
                else if (this.Bright == IlluminatorBrightness.WarmWhite)
                    bright = "Warm White";
                else
                    bright = "Auto";
            }
            else
            {
                bright = "--";
            }
            return base.ToString() + " Яркость:" + bright;
        }
    }
}
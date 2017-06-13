using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleSmartHouse1._0
{
     class TV : Device, IModeDefaultSettingsAble, IChannelAble,ISetChannelAble,  IVolumeAble, IBrightAble<BrightnessLevel>
    {
        List<string> tvChannelList = new List<string>();
        private BrightnessLevel bright { get; set; }
        public IChangeSettingAble ChangeParams { get; set; }
        public IParametrAble ChannelParam { get; set; }
        public IParametrAble VolumeParam { get; set; }
        public IListOrderAble ListFunction { get; set; }
        private bool channelLoadState;
        private string chanList = "Channel list:";
        private string readPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/ChannelList/ReadTVChannel.txt";

        public BrightnessLevel Bright{
            get { return bright; }
            set { bright = value; }
        }

        public int Channel {
            get {return ChannelParam.Current;}
            set { ChannelParam.Current = value;}
        }

        public int Volume {
            get {return VolumeParam.Current; }
            set { VolumeParam.Current = value; }
        }

        public TV(string name, bool state, IParametrAble channelParam, IParametrAble volumeParam, IChangeSettingAble changeParams, BrightnessLevel bright, IListOrderAble listFunction) : base (name, state)
        {
            Name = name;
            State = state;
            ChannelParam = channelParam;
            VolumeParam = volumeParam;
            ChangeParams = changeParams;
            this.bright = bright;
            ListFunction = listFunction;
        }
        public void LoadChannel()
        {
            if (true == State)
            {
                channelLoadState = true;
                ListFunction.ListLoad(tvChannelList, readPath);
            }
        }

        //Volume
        public void IncreaseVolume()
        {
            Volume = ChangeParams.Increase(Volume);
        }

        public void DecreaseVolume()
        {
            Volume = ChangeParams.Decrease(Volume);
        }

        public void HandSetVolume(int inputData)
        {
            Volume = ChangeParams.HandSet(inputData);
        }

        //Channel
        public void IncreaseChannel()
        {
            Channel = ChangeParams.Increase(Channel);
        }

        public void DecreaseChannel()
        {
            Channel = ChangeParams.Decrease(Channel);
        }

        public void HandSetChannel(int inputData)
        {
            Channel = ChangeParams.HandSet(inputData);
        }

        public string ShowChannelList()
        {     
                return ListFunction.ShowList(tvChannelList, chanList);
        }

        //BrightnessLevel
        public void SetMaxMode()
        {
            Bright = BrightnessLevel.Bright;
        }

        public void SetMiddleMode()
        {
            Bright = BrightnessLevel.Medium;
        }

        public void SetMinMode()
        {
            Bright = BrightnessLevel.Low;
        }

        public void SetAutoMode()
        {
            Bright = BrightnessLevel.Default;
        }


        public void IncreaseBrightness()
        {
            Volume = ChangeParams.Increase(Volume);
        }

        public void DecreaseBrightness()
        {
            Volume = ChangeParams.Decrease(Volume);
        }

        public override string ToString()
        {
            string channelName;
            string channelNumber;
            string volume;
            string bright;

            string channelLoadState;

            if (State == true)
            {
                volume = Volume.ToString();
                bright = Bright.ToString();
                if (this.channelLoadState == true)
                {
                    channelName = tvChannelList[Channel];
                    channelNumber = Channel.ToString();
                    channelLoadState = "Loaded";
                }
                else {
                    channelLoadState = "Need to load";
                    channelName = "--";
                    channelNumber = "--";
                }
            }
            else
            {
                channelLoadState = "Need to load";
                channelName = "--";
                channelNumber = "--";
                volume = "--";
                bright = "--";
            }
            return base.ToString() + " Channel:" + channelNumber + ":" + channelName + " Channel state:" + channelLoadState + " Volume:" + volume + " Bright:" + bright;
        }
    }
}

namespace SimpleSmartHouse1._0
{
 public abstract class Device
    {
        public string Name { get; set; }
        public bool State { get; set; }

        public Device()
        {   }
        public Device( string name, bool state)
          {
            Name = name;
            State = state;
        }

        public virtual void SwtchOn()
         {
            State = true;
         }

        public void SwtchOff()
        {
            State = false;
        }

        public override string ToString()
        {
            string State;
            if (this.State)
            {
                State = "ON";
            }
            else
            {
                State = "OFF";
            }
            return "State:" + State;
        }
    }
}


using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleSmartHouse1._0
{
    [DataContract]
    public abstract class Device
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        public bool State { get; set; }

        [Key]
        [DataMember]
        [Required]
        public int Id { get; set; }

        public Device()
        {   }

        public Device(string name, bool state)
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

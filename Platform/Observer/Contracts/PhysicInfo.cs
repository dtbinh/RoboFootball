using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Observer.DataContracts
{
    [DataContract]
    public class PhysicInfo
    {
        [DataMember]
        public DateTime TimeStemp { get; set; }
        [DataMember]
        public Point Coordinates { get; set; }
        [DataMember]
        public Point Direction { get; set; }
        [DataMember]
        public Point Speed { get; set; }
        [DataMember]
        public Point Acceleration { get; set; }
    }
}
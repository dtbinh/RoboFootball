using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Configuration.DataContracts
{

    [DataContract]
    public class GameRules
    {
    }


    [DataContract]
    public class GameGeometry
    {
        [DataMember]
        public int FieldRadius { get; set; }

        [DataMember]
        public int GateWidth { get; set; }

        [DataMember]
        public int BallRadius { get; set; }
    }

    [DataContract]
    public class GameTimings
    {
        [DataMember]
        public DateTime GameStartDate { get; set; }

        [DataMember]
        public int BeforeStartTimeoutLength { get; set; }

        [DataMember]
        public int TimeLength { get; set; }

        [DataMember]
        public int TimeCount { get; set; }

        [DataMember]
        public int TimeOutLength { get; set; }
    }
}

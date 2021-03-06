﻿using System;
using System.Runtime.Serialization;

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
        public TimeSpan TimeLength { get; set; }

        [DataMember]
        public byte TimeCount { get; set; }

        [DataMember]
        public TimeSpan TimeOutLength { get; set; }
    }
}

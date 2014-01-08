using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Configuration.DataContracts
{
    [DataContract]
    public class GameMembership
    {
        [DataMember]
        public int TeamCount { get { return Teams.Count; } }

        [DataMember]
        public IList<TeamMembership> Teams { get; set; }
        
    }

    [DataContract]
    public class TeamMembership
    {
        [DataMember]
        public string TeamName { get; set; }

        [DataMember]
        public byte TeamId { get; set; }

        [DataMember]
        public int PlayerCount { get { return Players.Count; } }

        [DataMember]
        public IList<PlayerData> Players { get; set; }

        [DataMember]
        public byte GateId { get; set; }
    }

    [DataContract]
    public class PlayerData
    {
        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public byte PlayerId { get; set; }

        [DataMember]
        public byte TeamId { get; set; }
      
        [DataMember]
        public int PlayerWidth { get; set; }

        [DataMember]
        public int PlayerLength { get; set; }

        [DataMember]
        public int PlayerMarkerPositionX { get; set; }

        [DataMember]
        public int PlayerMarkerPositionY { get; set; }

        [DataMember]
        public Color Marker { get; set; }

        [DataMember]
        public byte MachineId { get; set; }

    }
}

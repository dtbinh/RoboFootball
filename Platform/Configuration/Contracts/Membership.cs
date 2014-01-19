using System;
using System.Collections.Generic;
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
        public int ControlCenterCount { get { return ControlCenters.Count; } }

        [DataMember]
        public IList<ControllCenterData> ControlCenters { get; set; }

        [DataMember]
        public byte GateId { get; set; }
    }

    [DataContract]
    [KnownType(typeof(PlayerData))]
    [KnownType(typeof(ControllCenterData))]
    public abstract class UnitData
    {
        [DataMember]
        public byte Id { get; set; }

        [DataMember]
        public byte TeamId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class ControllCenterData:UnitData
    {

    }

    [DataContract]
    public class PlayerData:UnitData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public RobotData RobotData { get; set; }
    }

    [DataContract]
    public class RobotData
    {
        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte MachineId { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public int MarkerPositionX { get; set; }

        [DataMember]
        public int MarkerPositionY { get; set; }

        [DataMember]
        public Color Marker { get; set; }

    }

    [DataContract]
    public class Color
    {
        [DataMember]
        public byte r { get; set; }

        [DataMember]
        public byte g { get; set; }

        [DataMember]
        public byte b { get; set; }

        [DataMember]
        public byte a { get; set; }
    }
}

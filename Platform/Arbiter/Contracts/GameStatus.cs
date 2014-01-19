﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Arbiter.DataContracts
{
    [DataContract]
    class GameStatus
    {
        [DataMember]
        public string Message { get; set { Message = value + String.Format(" Game state is: {0}", GameState); } }
        [DataMember]
        public GameState GameState { get; set; }
    }

    [DataContract]
    public enum GameState
    {
        [EnumMember]
        NotStarted = "Nothing is started",
        [EnumMember]
        Started = "The game process has been started. The time is not started.",
        [EnumMember]
        Ended = "The game process has been started. All of times are ended. Wait administrator to switch off the game.",
        [EnumMember]
        InTime= "The game process has been started, the time has been also started. All players could act.",
        [EnumMember]
        TimeSuspended = "The game process has been started. The time has been suspended by administrator. Clock are stoppend. No one of players could act.",
        [EnumMember]
        TimeContinue = "The game process has been started. The time has been continued by administrator. Clock are started. All players could act.",
        [EnumMember]
        TimeOut = "The game process has been started. The time was ended. All acts of players are not supervised",
        [EnumMember]
        TimeOut = "The game process has been started. The time was ended. All acts of players are not supervised",
    }

}
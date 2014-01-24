using Arbiter.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Arbiter.DataContracts
{

    [DataContract]
    public class GameStatus
    {
        [DataMember]
        public string Message {get;set;}
        [DataMember]
        public IGameState State { get; set; }
    }

}

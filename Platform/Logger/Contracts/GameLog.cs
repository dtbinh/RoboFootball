using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Logger.Contracts
{
    [DataContract]
    [KnownType(typeof(PlayerLog))]
    [KnownType(typeof(ControllCenterLog))]
    public class GameLog
    {
        protected DateTime timeStamp;
        [DataMember]
        public DateTime TimeStamp { get { return timeStamp; } set { timeStamp = DateTime.Now; } }

        [DataMember]
        public string log;
        
        public virtual string ToLog(string delimiter)
        {
                var sb = new StringBuilder();
                sb.Append(timeStamp);
                sb.Append(delimiter);
                sb.Append(log);
                return sb.ToString();
        }
    }

    [DataContract]
    public class PlayerLog : GameLog
    {
        [DataMember]
        public ConfigurationSvc.PlayerData PlayerData { set; get; }

        public override string ToLog(string delimiter)
        {
            var sb = new StringBuilder();
            sb.Append(timeStamp);
            sb.Append(delimiter);

            if (PlayerData == null)
            {
                sb.Append("Player data==null");
                sb.Append(delimiter);
            }
            else
            {
                sb.Append(PlayerData.Id);
                sb.Append(delimiter);

                sb.Append(PlayerData.TeamId);
                sb.Append(delimiter);

                sb.Append(PlayerData.MachineId);
                sb.Append(delimiter);

                sb.Append(PlayerData.Name);
                sb.Append(delimiter);

            }

            sb.Append(log);
            return sb.ToString();
        }
    }

    [DataContract]
    public class ControllCenterLog : GameLog
    {
        [DataMember]
        public ConfigurationSvc.ControllCenterData ControllCenterData { set; get; }

        public override string ToLog(string delimiter)
        {
            var sb = new StringBuilder();
            sb.Append(timeStamp);
            sb.Append(delimiter);

            if (ControllCenterData == null)
            {
                sb.Append("Controll Center Data==null");
                sb.Append(delimiter);
            }
            else
            {
                sb.Append(ControllCenterData.Id);
                sb.Append(delimiter);

                sb.Append(ControllCenterData.TeamId);
                sb.Append(delimiter);
            }

            sb.Append(log);
            return sb.ToString();
        }
    }
}

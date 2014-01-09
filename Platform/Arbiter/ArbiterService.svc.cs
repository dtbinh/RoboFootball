using Arbiter.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : ConfigurationSvc.INotificationManagerCallback
    {
        public void OnConfigurationIsReady()
        {
            using (var timeManager = new ConfigurationSvc.TimingManagerClient())
            {
                var dateofstart = timeManager.GetGameTimings().GameStartDate;
                double millisecondsToWait = (dateofstart - DateTime.Now).TotalMilliseconds;
                if (millisecondsToWait < 0) throw new NotImplementedException("here should be called mvc client with message that the time has run out");
                System.Threading.Timer timer = new Timer((o) => { StartTheGame(); }, null, (uint)millisecondsToWait, 0);
            }
        }

        private void StartTheGame()
        {
            //create several subarbiters
            //call back to client
        }
    }
}

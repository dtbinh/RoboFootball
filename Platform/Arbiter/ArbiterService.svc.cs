using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Linq;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : ConfigurationSvc.INotificationManagerCallback
    {
        GameProcessManager gpm;
        private LoggerSvc.StatusMessageLoggerClient statusClient;
        private ConfigurationSvc.TimingManagerClient timingClient;
        private ConfigurationSvc.MembershipManagerClient teamManagerClient;

        public ArbiterService()
        {
            //statusClient= new LoggerSvc.StatusMessageLoggerClient();
            //timingClient = new ConfigurationSvc.TimingManagerClient();
            //teamManagerClient = new ConfigurationSvc.MembershipManagerClient();
            //gpm= new GameProcessManager(teamManagerClient,timingClient,statusClient);
        }

        public void OnConfigurationIsReady()
        {
            gpm.PerformGmameProcess();
            statusClient.Close();
            timingClient.Close();
            teamManagerClient.Close();
        }
    }
}

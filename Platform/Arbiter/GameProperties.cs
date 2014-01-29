using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arbiter.ConfigurationSvc;
using Arbiter.LoggerSvc;

namespace Arbiter
{
    public class GameProperties
    {
    

        public IMembershipManager Membership { get; private set; }
        public ITimingManager Timing { get; private  set; }
        public INotificationManager Notification { get; private set; }
        public ILogManager Logger { get; private set; }

        public GameProperties(IMembershipManager membership, 
                              ITimingManager timing, 
                              INotificationManager notification, 
                              ILogManager logger)
        {

            //TODO: for each set!
            //TODO: test if this services are available;
            //TODO: test if this links are not null 

            Membership = membership;
            Timing = timing;
            Notification = notification;
            Logger = logger;
        }
    }

}

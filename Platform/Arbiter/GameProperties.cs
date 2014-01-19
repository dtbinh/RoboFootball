using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbiter
{
    class GameProperties
    {
        public ConfigurationSvc.IMembershipManager Membership { get; set; }
        public ConfigurationSvc.ITimingManager Timing { get; set; }
        public LoggerSvc.IStatusMessageLogger Logger { get; set; }


        public GameProperties(ConfigurationSvc.IMembershipManager Membership,
                                  ConfigurationSvc.ITimingManager Timing,
                                  LoggerSvc.IStatusMessageLogger Logger)
        {
            //TODO: test if this services are available;
            if (Membership == null) throw new ArgumentException("Team Manager Client Should not be null");
            if (Timing == null) throw new ArgumentException("Timing Client Should not be null");
            if (Logger == null) throw new ArgumentException("Status Client Should not be null");
            this.Membership = Membership;
            this.Timing = Timing;
            this.Logger = Logger;
        }
    }

}

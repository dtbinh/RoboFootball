using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbiter
{
    class GameProperties
    {
        //TODO: for each set!
        //TODO: test if this services are available;
        //TODO: test if this links are not null     

        public ConfigurationSvc.IMembershipManager Membership { get; set; }
        public ConfigurationSvc.ITimingManager Timing { get; set; }
        public LoggerSvc.IStatusMessageLogger Logger { get; set; }


    }

}

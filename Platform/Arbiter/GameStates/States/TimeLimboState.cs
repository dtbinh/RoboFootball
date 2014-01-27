using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbiter.States
{
    class TimeLimboState:ITimeState
    {
        public void goNext(TimeContext context)
        {
        }

        public string Description
        {
            get
            {
                return "All times are out . " +
                        "All supervisors are alive but not active. " +
                        "Timers are stopped. " +
                        "Players are not active. " +
                        "Wait for the administrator to end the game.";
            }
        }
    }
}

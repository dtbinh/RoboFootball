using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class TimeInProgressState:ITimeState
    {
        public void goNext(TimeContext context)
        {
            StateService.Instance.SetStateTo<TimeEndedState>(context);
        }

        public string Description
        {
            get
            {
                return "The time has been started. " +
                        "All supervisors are alive but and active. " +
                        "Timers are started. " +
                        "Players are active. ";
            }
        }
    }
}
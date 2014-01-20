using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class TimeEndedState:ITimeState
    {
        public void goNext(TimeContext context)
        {
            context.currentTimeInc();
            if (context.currentTime <= context.timeCount)
                StateService.Instance.SetStateTo<TimeInProgressState>(context);
            else
                StateService.Instance.SetStateTo<TimeLimboState>(context);
        }

        public string Description
        {
            get
            {
                return "The time has been ended " +
                        "All supervisors are alive but not active. " +
                        "Timers are stopped. " +
                        "Players are active. " +
                        "Wait for the administrator to continue the game.";
            }
        }
    }
}
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
                context.CurrentTimeState = new TimeInProgressState();
            else
                context.CurrentTimeState = new TimeFinishState();
        }
    }
}
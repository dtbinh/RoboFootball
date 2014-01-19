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
            context.CurrentTimeState = new TimeEndedState();
        }
    }
}
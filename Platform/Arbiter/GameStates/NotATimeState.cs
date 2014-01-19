using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class NotATimeState:ITimeState
    {
        public void goNext(TimeContext context)
        {
            if(context.timeCount!=0)
                context.CurrentTimeState = new TimeInProgressState();
            else
                context.CurrentTimeState = new TimeFinishState();
        }
    }
}
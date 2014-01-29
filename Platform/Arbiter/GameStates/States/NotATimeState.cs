using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class NotATimeState : ITimeState
    {
        public void goNext(TimeContext context)
        {
            if (context.TimeCount != 0)
                StateService.Instance.SetStateTo<TimeInProgressState>(context);
            else
                StateService.Instance.SetStateTo<TimeLimboState>(context);
        }

        public string Description
        {
            get { return ""; }
        }
    }
}
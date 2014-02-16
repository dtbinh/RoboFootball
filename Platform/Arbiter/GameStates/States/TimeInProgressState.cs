using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class TimeInProgressState : ITimeState
    {
        public void goNext(TimeContext context)
        {
            activateSupervisors(context.GameProperties);
            var timer = TimeService.Instance.GameTimer;
            var timeLength = context.GameProperties.Timing.GetGameTimings().TimeLength;
            timer.SetTime(timeLength);
            timer.CallAfter(() =>
                                {
                                   
                                    StateService.Instance.SetStateTo<TimeEndedState>(context);
                                }
                );
            timer.Start();
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

        private void activateSupervisors(GameProperties gameProperties)
        {
            var players = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players);
            var supervisors = players.Select(p => SupervisorsService.Instance.GetSupervisorFor(p));
            SupervisorsService.Instance.StartSupervisors(supervisors);
        }
    }
}
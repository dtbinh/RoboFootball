using System.Linq;

namespace Arbiter.States
{
    public class TimeEndedState : ITimeState
    {
        public void goNext(TimeContext context)
        {
            disActivateSupervisors(context.GameProperties);
            TimeService.Instance.PauseTimer.CallAfter(() =>
            {
                context.CurrentTimeInc();
                if (context.CurrentTime <= context.TimeCount)
                    StateService.Instance.SetStateTo<TimeInProgressState>(context);
                else
                    StateService.Instance.SetStateTo<TimeLimboState>(context);
            });
            TimeService.Instance.PauseTimer.Start();
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

        private void disActivateSupervisors(GameProperties gameProperties)
        {
            var players = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players);
            var supervisors = players.Select(p => SupervisorsService.Instance.GetSupervisorFor(p));
            SupervisorsService.Instance.SuspendSupervisors(supervisors);
        }
    }
}
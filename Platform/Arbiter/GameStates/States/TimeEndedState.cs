using System.Linq;

namespace Arbiter.States
{
    public class TimeEndedState : ITimeState
    {
        public void goNext(TimeContext context)
        {
            disActivateSupervisors(context.GameProperties);

            var timer = TimeService.Instance.GameTimer;
            var timeLength = context.GameProperties.Timing.GetGameTimings().TimeOutLength;
            timer.SetTime(timeLength);
            /*
            * Возможно нужно реализовать писателей-читателей на месте смена контекста
             * То есть, если тут работает главный поток - евент таймера ждет пока он закончится, а потом меняет состояние
             * Если работает поток таймера - то главный поток вообще не может войти в goNext
             * ВОзможно таймеру надо передовать вообще весь goNext
            */
            timer.CallAfter(() =>
                                {
                context.CurrentTimeInc();
                if (context.CurrentTime <= context.TimeCount)
                    StateService.Instance.SetStateTo<TimeInProgressState>(context);
                else
                    StateService.Instance.SetStateTo<TimeLimboState>(context);
                System.Console.WriteLine("Current time "+ context.CurrentTime);
                
            });

            timer.Start();
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
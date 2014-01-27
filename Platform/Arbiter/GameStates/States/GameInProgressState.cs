using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GameInProgressState : IGameState
    {
        public void goNext(GameContext context)
        {
            var robotsAreReady = PrepareRobots(context.gameProperties);

            var timeLimboState = StateService.Instance.State<TimeLimboState>();

            if (context.timeContext.CurrentTimeState.Equals(timeLimboState))
                StateService.Instance.SetStateTo<GameEndedState>(context);
            else
            {
                context.timeContext.goNext();
                StateService.Instance.SetStateTo<GameInProgressState>(context);
            }
        }

        public string Description
        {
            get
            {
                return "The game process has been started. " +
                        "All supervisors are alive but not active. " +
                        "Timers are started. " +
                        "Players are active. " +
                        "Wait for the administrator to start first time.";
            }
        }

        private bool PrepareRobots(GameProperties gameProperties)
        {
            var robots = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players.Select(p => p.RobotData));
            if (!robots.Any(r => !r.IsActive)) return true;
            foreach (var robot in robots)
            {
                robot.IsActive = true;
                throw new NotImplementedException("Here should be call to Communication module with special activation code for robot with special id!");
                throw new NotImplementedException("only in a case if robto is activated returned true!!");
                return false;
            }
            return false;
        }


        private Tuple<IGameTimer, IGameTimer> PrepareTimers(GameProperties gameProperties)
        {
            var timings = gameProperties.Timing.GetGameTimings();
            var gametimer = TimeService.Instance.GameTimer;
            gametimer.SetTime(timings.TimeLength);

            var pausetimer = TimeService.Instance.PauseTimer;
            pausetimer.SetTime(timings.TimeOutLength);

            if (gametimer != null && pausetimer != null) return new Tuple<IGameTimer, IGameTimer>(gametimer, pausetimer);

            return null;
        }


    }
}
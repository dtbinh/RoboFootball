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
            get { return "The game process has been started. "+ 
                          "All supervisors are alive but not active. "+
                          "Timers are started. "+
                          "Players are active. " + 
                          "Wait for the administrator to start first time."; }
        }

        private var PrepareRobots(GameProperties gameProperties)
        {
            var robots = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players.Select(p => p.RobotData));
            foreach (var robot in robots)
            {
                robot.IsActive = true;
            }

        }



        private void NextStep(GameContext context)
        {
            var timeLimboState = StateService.Instance.State<TimeLimboState>();

            if (context.timeContext.CurrentTimeState.Equals(timeLimboState))
                StateService.Instance.SetStateTo<GameEndedState>(context);
            else
            {
                context.timeContext.goNext();
                StateService.Instance.SetStateTo<GameInProgressState>(context);
            }
        }


        public bool PrepareGame(GameProperties gameProperties)
        {
            var robots = ActivateRobotsOfPalyers(gameProperties);
            var pauseTimer = TimeService.Instance.PauseTimer;
            var difference= DateTime.Now.Subtract(gameProperties.Timing.GetGameTimings().GameStartDate);
            pauseTimer.SetTime(difference);
            pauseTimer.CallAfter(NextStep);


            var timers = PrepareTimers(gameProperties);

            if (supervisors != null && timers != null) return true;
            return false;

        }

        private IList<SupervisorsService.Supervisor> PrepareSupervisors(GameProperties gameProperties)
        {
            var membership = gameProperties.Membership.GetMembership();
            var supervisors = SupervisorsService.Instance.CreateSupervisorsFor(membership);
            if (supervisors != null && supervisors.Any()) return supervisors;
            return null;
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
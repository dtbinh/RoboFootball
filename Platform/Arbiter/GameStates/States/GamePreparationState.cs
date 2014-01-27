using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GamePreparationState : IGameState
    {
        public void goNext(GameContext context)
        {
            if (PrepareGame(context.gameProperties))
            StateService.Instance.SetStateTo<GameInProgressState>(context);
            else
            StateService.Instance.SetStateTo<NotAGameState>(context);
        }

        public string Description
        {
            get
            {
                return "Preparation for the game has been ended. " +
                        "All supervisors are alive but not active. " +
                        "Timers are not started. " +
                        "Players are not active. " +
                        "Wait for the administrator to start the game.";
            }
        }

        public bool PrepareGame(GameProperties gameProperties)
        {
            var supervisors = PrepareSupervisors(gameProperties);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GamePreparationState:IGameState
    {
        public void goNext(GameContext context)
        {
            StateService.Instance.SetStateTo<GameInProgressState>(context);
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
            var membership = gameProperties.Membership.GetMembership();
            var supervisors=SupervisorsService.Instance.CreateSupervisorsFor(membership);
           
            var timings = gameProperties.Timing.GetGameTimings();
            var gametimer = getTimer(timings);
        }

        private bool PrepareSupervisors(GameProperties gameProperties)
        {
            var membership = gameProperties.Membership.GetMembership();
            var supervisors = SupervisorsService.Instance.CreateSupervisorsFor(membership);
            if (supervisors == null || !supervisors.Any()) return false;
            return false;
        }


    }
}
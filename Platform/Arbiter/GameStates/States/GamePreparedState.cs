using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GamePreparedState:IGameState
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
    }
}
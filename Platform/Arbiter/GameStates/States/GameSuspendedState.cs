using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GameSuspendedState : IGameState
    {

        public void goNext(GameContext context)
        {
            StateService.Instance.SetStateTo<GameInProgressState>(context);
        }

        public string Description
        {
            get
            {
                return  "The game process has been suspended. " +
                        "All supervisors are alive but not active. " +
                        "Timers are stopped. " +
                        "Players are not active. " +
                        "Wait for the administrator to continue the game.";
            }
        }
    }
}
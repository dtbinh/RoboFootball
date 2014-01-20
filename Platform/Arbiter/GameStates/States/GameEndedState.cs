using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GameEndedState : IGameState
    {
        public void goNext(GameContext context)
        {
            StateService.Instance.SetStateTo<NotAGameState>(context);
        }

        public string Description
        {
            get
            {
                return "The game process has been ended. " +
                        "All supervisors are dead. " +
                        "Timers are stopped. " +
                        "Players are dead. " +
                        "Wait for the administrator to quit game process.";
            }
        }
    }
}
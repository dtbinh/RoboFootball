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

            if(context.timeContext.CurrentTimeState.Equals(timeLimboState))
            StateService.Instance.SetStateTo<GameEndedState>(context);
            else
                StateService.Instance.SetStateTo<GameInProgressState>(context);
        }

        public string Description
        {
            get { return "The game process has been started. "+ 
                          "All supervisors are alive but not active. "+
                          "Timers are started. "+
                          "Players are active. " + 
                          "Wait for the administrator to start first time."; }
        }
    }
}
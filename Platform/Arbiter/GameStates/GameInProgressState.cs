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
            var finishedState = StateService.Instance.State<TimeFinishState>();

            if(context.timeContext.CurrentTimeState.Equals(finishedState))
            StateService.Instance.SetStateTo<GameEndedState>(context);
            else
                StateService.Instance.SetStateTo<GameInProgressState>(context);
        }
    }
}
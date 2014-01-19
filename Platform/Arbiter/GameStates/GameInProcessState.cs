using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GameInProcessState : IGameState
    {
        public void goNext(GameContext context)
        {
            //TODO make it in more convenient way
            if(context.timeContext.CurrentTimeState.GetType() == typeof(TimeFinishState))
            context.CurrentGameState = new GameEndedState();
            else
            context.CurrentGameState = new GameInProcessState();
        }
    }
}
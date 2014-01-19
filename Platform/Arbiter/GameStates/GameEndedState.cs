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
            context.CurrentGameState = new NotAGameState();
        }
    }
}
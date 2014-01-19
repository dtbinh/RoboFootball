﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class NotAGameState:IGameState
    {
        public void goNext(GameContext context)
        {
            context.CurrentGameState = new GamePreparedState();
        }
    }
}
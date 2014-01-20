﻿using System;
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
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbiter.States
{
    public interface IGameState:IState
    {
        void goNext(GameContext context);
    }
}

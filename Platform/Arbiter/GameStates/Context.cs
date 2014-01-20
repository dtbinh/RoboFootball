using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbiter.States
{

    class GameContext
    {
        public IGameState CurrentGameState { set; get; }
        public TimeContext timeContext { get; private set; }
        public GameContext(TimeContext timeContext)
        {
            StateService.Instance.SetStateTo<NotAGameState>(this);
            if (timeContext == null) throw new ArgumentException("TimeContext could not be null");
            this.timeContext = timeContext;
        }
        public void goNext()
        {
            CurrentGameState.goNext(this);
        }
    }

    class TimeContext 
    {
        public ITimeState CurrentTimeState { get; set; }
        public byte currentTime { get; private set; }
        public  byte timeCount{get; private set;}
        public TimeContext(byte timeCount)
        {
            if (timeCount>=0) this.timeCount=timeCount;
            else timeCount=0;
            CurrentTimeState = new NotATimeState();
        }
        public void goNext()
        {
            CurrentTimeState.goNext(this);
        }
        public void currentTimeInc() {currentTime++; }

    }

    

}

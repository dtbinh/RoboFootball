using System;

namespace Arbiter.States
{

    public class GameContext
    {
        public IGameState CurrentGameState { set; get; }
        public TimeContext TimeContext { get; private set; }

        public GameProperties GameProperties { get; private  set; }

        public GameContext(TimeContext timeContext)
        {
            StateService.Instance.SetStateTo<NotAGameState>(this);
            if (timeContext == null) throw new ArgumentException("TimeContext could not be null");
            this.TimeContext = timeContext;
            GameProperties = timeContext.GameProperties;
        }
        public void GoNext()
        {
            CurrentGameState.goNext(this);
        }
    }

    public class TimeContext 
    {
        public ITimeState CurrentTimeState { get; set; }
        public byte CurrentTime { get; private set; }
        public  byte TimeCount{get; private set;}
        public GameProperties GameProperties { get; private set; }
        public TimeContext(GameProperties gameProperties)
        {
            GameProperties = gameProperties;
            TimeCount = gameProperties.Timing.GetGameTimings().TimeCount;
            StateService.Instance.SetStateTo<NotATimeState>(this);
        }

        public void GoNext()
        {
            CurrentTimeState.goNext(this);
        }
        public void CurrentTimeInc() {CurrentTime++; }

    }

    

}

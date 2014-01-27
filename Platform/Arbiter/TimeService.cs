using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Web;

namespace Arbiter
{
    public class TimeService
    {
        private static TimeService instance;
        public static TimeService Instance
        {
            get
            {
                if (Instance == null) { instance = new TimeService(); }
                return instance;
            }
        }

        public IGameTimer GameTimer { get; private set; }
        public IGameTimer PauseTimer { get; private set; }
        private TimeService()
        {
            GameTimer = new GameTimer();
            PauseTimer = new GameTimer();
        }
    }

    public interface IGameTimer
    {
        void SetTime(TimeSpan timeSpan);
        TimeSpan TimeRest { get; }
        bool Start();
        bool Stop();

        void CallAfter(Action EndTime, int number);
    }

    public class GameTimer : IGameTimer
    {
        Timer timer;
        Stopwatch stopWatch;
        bool inProcess = false;
        TimeSpan timeSpan { get; set; }
        Action callfunction;


        public void SetTime(TimeSpan timeSpan)
        {
            if (inProcess) return;
            this.timeSpan = timeSpan;
            timer = new System.Timers.Timer();
            timer.Interval = (int)timeSpan.TotalMilliseconds;
            stopWatch = new Stopwatch();
        }

        public TimeSpan TimeRest
        {
            get { return timeSpan.Add(-stopWatch.Elapsed); }
        }

        public bool Start()
        {
            if (inProcess) return false;
            timer.Start();
            stopWatch.Start();
            inProcess = true;
            return true;
        }

        public bool Stop()
        {
            if (!inProcess) return false;
            timer.Stop();
            stopWatch.Stop();
            inProcess = false;
            return true;
        }

        public void CallAfter(Action callfunction, int number)
        {
            if (inProcess) return;
            this.callfunction = callfunction;
            this.timeNumber = number;
            timer.Elapsed += timer_Elapsed;

        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            callfunction();
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Arbiter
{
    public class GameProcessManager
    {

        private LoggerSvc.IStatusMessageLogger statusClient;
        private  ConfigurationSvc.ITimingManager timingClient;
        private ConfigurationSvc.IMembershipManager teamManagerClient;

        public GameProcessManager(ConfigurationSvc.IMembershipManager teamManagerClient,
                                  ConfigurationSvc.ITimingManager timingClient,
                                  LoggerSvc.IStatusMessageLogger statusClient)
        {
            //TODO: test if this services are available;
            if (teamManagerClient == null) throw new ArgumentException("Team Manager Client Should not be null");
            if (timingClient == null) throw new ArgumentException("Timing Client Should not be null");
            if (statusClient == null) throw new ArgumentException("Status Client Should not be null");
            this.teamManagerClient = teamManagerClient;
            this.timingClient = timingClient;
            this.statusClient = statusClient;
        }

        private IEnumerable<PlayerSupervisor> supervisors;

        public void PerformGmameProcess()
        {
            var timings = timingClient.GetGameTimings();

            StartGame();
            StartTime(0);

            for (int i = 0; i < timings.TimeCount - 1; i++)
            {
                EndTime(i);
                TimeOut();
                StartTime(i + 1);
            }
            EndTime(0);
            EndGame();
        }

        public void StartGame()
        {
            statusClient.ShowStatusMessage("The game has started initialization...");

            var dateofstart = timingClient.GetGameTimings().GameStartDate;
            double millisecondsToWait = (dateofstart - DateTime.Now).TotalMilliseconds;
            if (millisecondsToWait < 0) throw new NotImplementedException("here should be called mvc client with message that the time has run out");

            Thread.Sleep((int)millisecondsToWait);

            statusClient.ShowStatusMessage("The game has been started");

            ActivateSupervisors();

            statusClient.ShowStatusMessage("SubArbiters has been activated");

            //notofocation to user
        }

        public void EndGame()
        {
            statusClient.ShowStatusMessage("Ending of the game");
            DisactivatePlayers();
            DisactivateSupervisors();
            statusClient.ShowStatusMessage("The game has been ended");
        }

        public void StartTime(int number)
        {
            statusClient.ShowStatusMessage("Time " + number + " is starting");
            var gameTime = timingClient.GetGameTimings().TimeLength;
            Thread.Sleep(gameTime);
            ActivatePlayers();
            statusClient.ShowStatusMessage("Players are activated");
        }

        public void EndTime(int number)
        {
            statusClient.ShowStatusMessage("Time " + number + "ended");
            DisactivatePlayers();
            statusClient.ShowStatusMessage("Players are disactivated");
        }

        public void TimeOut()
        {
            statusClient.ShowStatusMessage("Time out started");
            var pause = timingClient.GetGameTimings().TimeOutLength;
            Thread.Sleep(pause);
            statusClient.ShowStatusMessage("Time out ended");
        }

        public void ActivatePlayers()
        {
            //Вот эти штуки надо имплементить через CommunicationService!
            //    Это будет такой сервис, который умеет посылать сообщения роботам и хранит список готовых сообщений
            throw new NotImplementedException();
        }

        public void DisactivatePlayers()
        {
        }

        public void ActivateSupervisors()
        {
            var mem = teamManagerClient.GetMembership();
            supervisors = mem.Teams.SelectMany(team => team.Players)
                                   .Select(player => new PlayerSupervisor(player));

            foreach (var t in supervisors.Select(supervisor => new Thread(supervisor.CheckRules)))
            {
                t.Start();
            }
        }

        public void DisactivateSupervisors()
        {
            foreach (var s in supervisors)
            {
                s.RequestStop();
                //LoggerSvc.addLog
            }
        }
    }
}
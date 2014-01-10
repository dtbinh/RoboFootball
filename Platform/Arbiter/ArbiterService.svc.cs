using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Linq;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : ConfigurationSvc.INotificationManagerCallback
    {

        IEnumerable<PlayerSupervisor> supervisors;

        public void OnConfigurationIsReady()
        {
            using (var timeManager = new ConfigurationSvc.TimingManagerClient())
            {
                var timings = timeManager.GetGameTimings();

                StartGame(timings);
                StartTime(timings);

                for (int i = 0; i < timings.TimeCount - 1; i++)
                {
                    EndTime(timings);
                    TimeOut(timings);
                    StartTime(timings, i + 1);
                }
                EndTime(timings);
                EndGame(timings);
            }
        }

        private void StartGame(ConfigurationSvc.GameTimings timings)
        {
            using (var status = new LoggerSvc.StatusMessageLoggerClient())
            {
                status.ShowStatusMessage("The game has started initialization...");

                var dateofstart = timings.GameStartDate;
                double millisecondsToWait = (dateofstart - DateTime.Now).TotalMilliseconds;
                if (millisecondsToWait < 0) throw new NotImplementedException("here should be called mvc client with message that the time has run out");

                Thread.Sleep((int)millisecondsToWait);

                status.ShowStatusMessage("The game has been started");

                ActivateSupervisors();

                status.ShowStatusMessage("SubArbiters has been activated");
            }

            //notofocation to user
        }

        private void EndGame(ConfigurationSvc.GameTimings timings)
        {
            using (var status = new LoggerSvc.StatusMessageLoggerClient())
            {
                status.ShowStatusMessage("Ending of the game");
                DisactivatePlayers();
                DisactivateSupervisors();
                status.ShowStatusMessage("The game has been ended");
            }
        }

        private void StartTime(ConfigurationSvc.GameTimings timings, int number)
        {
            using (var status = new LoggerSvc.StatusMessageLoggerClient())
            {
                status.ShowStatusMessage("Time " + number + " is starting");
                var gameTime = timings.TimeLength;
                Thread.Sleep(gameTime);
                ActivatePlayers();
                status.ShowStatusMessage("Players are activated");
            }
        }

        private void EndTime(ConfigurationSvc.GameTimings timings, int number)
        {
            using (var status = new LoggerSvc.StatusMessageLoggerClient())
            {
                status.ShowStatusMessage("Time " + number + "ended");
                DisactivatePlayers();
                status.ShowStatusMessage("Players are disactivated");
            }
        }

        private void TimeOut(ConfigurationSvc.GameTimings timings)
        {
            using (var status = new LoggerSvc.StatusMessageLoggerClient())
            {
                status.ShowStatusMessage("Time out started");
                var pause = timings.TimeOutLength;
                Thread.Sleep(pause);
                status.ShowStatusMessage("Time out ended");
            }
        }

        private void ActivatePlayers()
        {
            throw new NotImplementedException();
        }

        private void DisactivatePlayers()
        {
            throw new NotImplementedException();
        }


        private void ActivateSupervisors()
        {
            using (var teamsManager = new ConfigurationSvc.MembershipManagerClient())
            {
                var mem = teamsManager.GetMembership();
                supervisors = mem.Teams.SelectMany(team => team.Players)
                                       .Select(player => new PlayerSupervisor(player));
            }

            foreach (var t in supervisors.Select(supervisor => new Thread(supervisor.CheckRules)))
            {
                t.Start();
                //LoggerSvc.addLog
            }
        }

        private void DisactivateSupervisors()
        {
            foreach (var s in supervisors)
            {
                s.RequestStop();
                //LoggerSvc.addLog
            }
        }

    }
}

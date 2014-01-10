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
                var timings= timeManager.GetGameTimings();
                
                StartGame(timings);
                StartTime(timings);
                
                for (int i = 0; i < timings.TimeCount-1; i++)
                {
                    EndTime(timings);
                    TimeOut(timings);
                    StartTime(timings);
                }
                EndTime(timings);
                EndGame(timings);
            }
        }

        private void StartGame(ConfigurationSvc.GameTimings timings)
        {
            //notofocation to user

            var dateofstart = timings.GameStartDate;
            double millisecondsToWait = (dateofstart - DateTime.Now).TotalMilliseconds;
            if (millisecondsToWait < 0) throw new NotImplementedException("here should be called mvc client with message that the time has run out");
            
            Thread.Sleep((int)millisecondsToWait);
            ActivateSupervisors();
            //notofocation to user
        }

        private void EndGame(ConfigurationSvc.GameTimings timings)
        {
            //notofocation to user
            DisactivatePlayers();
            DisactivateSupervisors();
            //notofocation to user
        }


        private void StartTime(ConfigurationSvc.GameTimings timings)
        {
            //notofocation to user
            var gameTime = timings.TimeLength;
            Thread.Sleep(gameTime);
            ActivatePlayers();
            //notofocation to user
        }

        private void ActivatePlayers()
        {
            throw new NotImplementedException();
        }

        private void EndTime(ConfigurationSvc.GameTimings timings)
        {
            //notofocation to user
            DisactivatePlayers();
            //notofocation to user
        }

        private void DisactivatePlayers()
        {
            throw new NotImplementedException();
        }

        private void TimeOut(ConfigurationSvc.GameTimings timings)
        {
            //notofocation to user
            var pause = timings.TimeOutLength;
            Thread.Sleep(pause);
            //notofocation to user
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
                //notofocation to user
            }
        }

        private void DisactivateSupervisors()
        {
            foreach (var s in supervisors)
            {
                s.RequestStop();
                //notofocation to user
            }
        }

    }
}

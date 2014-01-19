using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Arbiter
{
    public class PlayerSupervisor
    {
        ConfigurationSvc.PlayerData palyer;
        ObserverSvc.PhysicInfo currentPhysicInfo;
        private ConfigurationSvc.PlayerData player;
        public bool IsSuspended { get; set; }
        public bool IsRun { get; set; }
        Thread thread;


        public PlayerSupervisor(ConfigurationSvc.PlayerData player)
        {
            if (player == null) throw new ArgumentException("Player data should not be null");
            this.palyer = player;
            IsRun = true;
            IsSuspended = false;
            thread = new Thread(this.CheckRules);
            thread.Start();
        }

        

        public void CheckRules()
        {
            while (IsRun)
            {
                if (IsSuspended) continue;
                //checking logic
            }
        }
    }

}
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
        private bool shouldStop;

        public PlayerSupervisor(ConfigurationSvc.PlayerData player)
        {
            if (player == null) throw new ArgumentException("Player data should not be null");
            this.palyer = player;
        }
        public void RequestStop()
        {
            shouldStop = true;
        }

        public void CheckRules()
        {
            while (!shouldStop)
            {
 
            }

        }
    }

}
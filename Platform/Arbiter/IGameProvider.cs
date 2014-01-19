using Arbiter.ConfigurationSvc;
using Arbiter.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arbiter
{
    interface IGameProvider
    {
        // Create supervisors etc
        //Could be only if Configuration is ready! (check for configuration is ready method)
        public GameStatus PrepareGame(GameProperties gameProperties);
        //Start game means change game status to GameStarted. (Could be only Game Ended before)
        //Check timings etc
        //Could be if game has been prepared
        public GameStatus StartGame(GameProperties gameProperties);
        public GameStatus EndGame(GameProperties gameProperties);
        public GameStatus StartTime(int number);
        public GameStatus EndTime(int number);
        public GameStatus TimeOut(GameProperties gameProperties);
        public GameStatus SuspendGame(GameProperties gameProperties);
        public GameStatus ResumeGame(GameProperties gameProperties);
        // robots could run they inner programs
        public bool ActivateRobotsOfPlayers(IEnumerable<PlayerData> playersToActivate);
        // robots could not run they inner programs
        public bool DisactivateRobotsOfPlayers(IEnumerable<PlayerData> playersToDisactivate);
        // This method starts Supervisor's threads 
        public bool ActivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        // This method ends Supervisor's threads
        public bool DisactivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToDisactivate);
        // This method stops Supervisor's rule checing process
        public bool SuspendSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        // This method starts Supervisor's rule checing process
        public bool StartSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        public IEnumerable<PlayerSupervisor> SupervisorFactory(Arbiter.ConfigurationSvc.GameMembership mem);
    }
}

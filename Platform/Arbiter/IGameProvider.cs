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
        //Could be only if Configuration is ready! (check for configuration is ready method)
        GameStatus PrepareGame(GameProperties gameProperties);
        //Start game means change game status to GameStarted. (Could be only Game Ended before)
        //Check timings etc
        //Could be if game has been prepared
        GameStatus StartGame(GameProperties gameProperties);
        GameStatus EndGame(GameProperties gameProperties);
        GameStatus StartTime(int number);
        GameStatus EndTime(int number);
        GameStatus TimeOut(GameProperties gameProperties);
        GameStatus SuspendGame(GameProperties gameProperties);
        GameStatus ResumeGame(GameProperties gameProperties);
        // robots could run they inner programs
        bool ActivateRobotsOfPlayers(IEnumerable<PlayerData> playersToActivate);
        // robots could not run they inner programs
        bool DisactivateRobotsOfPlayers(IEnumerable<PlayerData> playersToDisactivate);
        // This method starts Supervisor's threads 
        bool ActivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        // This method ends Supervisor's threads
        bool DisactivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToDisactivate);
        // This method stops Supervisor's rule checing process
        bool SuspendSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        // This method starts Supervisor's rule checing process
        bool StartSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        IEnumerable<PlayerSupervisor> SupervisorFactory(Arbiter.ConfigurationSvc.GameMembership mem);
    }
}

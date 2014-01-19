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
        public GameStatus StartGame(GameProperties gameProperties);
        public GameStatus EndGame();
        public GameStatus StartTime(int number);
        public GameStatus EndTime(int number);
        public GameStatus TimeOut();
        public GameStatus SuspendGame();
        public GameStatus ResumeGame();
        public bool ActivateRobotsOfPlayers(IEnumerable<PlayerData> playersToActivate);
        public bool DisactivateRobotsOfPlayers(IEnumerable<PlayerData> playersToDisactivate);
        public bool ActivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        public bool SuspendSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        public bool ContinueSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate);
        public bool DisactivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToDisactivate);
        public IEnumerable<PlayerSupervisor> SupervisorFactory(Arbiter.ConfigurationSvc.GameMembership mem);
        public IEnumerable<Thread> SupervisorThreadFactory(IEnumerable<PlayerSupervisor> supervisors);
    }
}

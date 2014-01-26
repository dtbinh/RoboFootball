using Arbiter.DataContracts;
using Arbiter.States;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Arbiter
{
    public class GameProvider : IGameProvider, ConfigurationSvc.INotificationManagerCallback
    {
        private GameContext context;
        private GameProperties gameProperties;
        private IList<PlayerSupervisor> supervisors;
        public IGameTimer gameTimer { get; private set; }
        public GameProvider(GameProperties gameProperties)
        {
            if (gameProperties == null) throw new ArgumentException("game properties should not be null");
            this.gameProperties = gameProperties;
            var timecount = gameProperties.Timing.GetGameTimings().TimeCount;
            context = new GameContext(new TimeContext(timecount));
        }

        public void OnConfigurationIsReady()
        {
            PrepareGame(this.gameProperties);
        }

        

        public GameStatus StartGame(GameProperties gameProperties)
        {
            var supervisorsAreActivated = ActivateSupervisors(supervisors);
            var teams = gameProperties.Membership.GetMembership().Teams;
            var robotsAreActivated = false;
            foreach (var team in teams)
            {
                robotsAreActivated &= ActivateRobotsOfPlayers(team.Players);
            }
            if (robotsAreActivated && supervisorsAreActivated)
            {
                context.goNext();
            }

            return new GameStatus
            {
                Message = context.CurrentGameState.Description,
                State = context.CurrentGameState
            };
        }

        public GameStatus EndGame(GameProperties gameProperties)
        {
            throw new System.NotImplementedException();
        }

        public GameStatus StartTime(int number)
        {
            gameTimer.SetTime(timings);
           
            //need to check contexts!
            gameTimer.CallAfter(EndTime,number); // make this in a more generic way!!!
            if (StartSupervisors(supervisors))
            {
                gameTimer.Start();
                context.goNext();
            }


        }

        public GameStatus EndTime(int number)
        {
            //need to check contexts!
            gameTimer.SetTime(timings);
            gameTimer.CallAfter(StartTime, number); // make this in a more generic way!!!
            if (DisactivateSupervisors(supervisors))
            {
                gameTimer.Stop();
                context.goNext();
            }
        }

        public GameStatus TimeOut(GameProperties gameProperties)
        {
            throw new System.NotImplementedException();
        }

        public GameStatus SuspendGame(GameProperties gameProperties)
        {
            throw new System.NotImplementedException();
        }

        public GameStatus ResumeGame(GameProperties gameProperties)
        {
            throw new System.NotImplementedException();
        }

        public bool ActivateRobotsOfPlayers(System.Collections.Generic.IEnumerable<ConfigurationSvc.PlayerData> playersToActivate)
        {
            throw new System.NotImplementedException();
        }

        public bool DisactivateRobotsOfPlayers(System.Collections.Generic.IEnumerable<ConfigurationSvc.PlayerData> playersToDisactivate)
        {
            throw new System.NotImplementedException();
        }


     


        public IGameTimer getTimer(ConfigurationSvc.GameTimings timings)
        {
            throw new NotImplementedException();
        }
    }
}














//using Arbiter.DataContracts;
//using Arbiter.States;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Web;

//namespace Arbiter
//{
//    public class GameProvider:IGameProvider
//    {
//        private GameContext gameContext;
//        private GameProperties gameProperties;
//        public GameProvider(GameProperties gameProperties)
//        {
//            if(gameProperties==null) throw new ArgumentException("game properties should not be null");
//            this.gameProperties = gameProperties;
//            var timecount = gameProperties.Timing.GetGameTimings().TimeCount;
//            gameContext = new GameContext(new TimeContext(timecount));
//        }
//        public GameStatus StartGame(GameProperties gameProperties)
//        {
//            gameContext.goNext();

//        }

//        public GameStatus EndGame()
//        {
//            gameContext.goNext();
//        }

//        public GameStatus StartTime(int number)
//        {
//            if (gameContext.CurrentGameState.GetType == typeof(GameInProgressState))
//                gameContext.timeContext.goNext();
//        }

//        public GameStatus EndTime(int number)
//        {
//            gameContext.goNext();
//        }

//        public GameStatus SuspendGame()
//        {
//            gameContext.CurrentGameState = new GameSuspendedState();
//        }

//        public GameStatus ResumeGame()
//        {
//            gameContext.CurrentGameState = new GameInProgressState();
//        }

//        public bool ActivateRobotsOfPlayers(IEnumerable<ConfigurationSvc.PlayerData> playersToActivate)
//        {
//            throw new NotImplementedException();
//        }

//        public bool DisactivateRobotsOfPlayers(IEnumerable<ConfigurationSvc.PlayerData> playersToDisactivate)
//        {
//            throw new NotImplementedException();
//        }

//        public bool ActivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate)
//        {
//            throw new NotImplementedException();
//        }

//        public bool DisactivateSupervisors(IEnumerable<PlayerSupervisor> supervisorsToDisactivate)
//        {
//            throw new NotImplementedException();
//        }

//        public bool SuspendSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate)
//        {
//            throw new NotImplementedException();
//        }

//        public bool StartSupervisors(IEnumerable<PlayerSupervisor> supervisorsToActivate)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<PlayerSupervisor> SupervisorFactory(ConfigurationSvc.GameMembership mem)
//        {
//            throw new NotImplementedException();
//        }

//        //public GameState State { get; set; }

//        //private LoggerSvc.IStatusMessageLogger statusClient;
//        //private  ConfigurationSvc.ITimingManager timingClient;
//        //private ConfigurationSvc.IMembershipManager teamManagerClient;

//        //public GameProvider(ConfigurationSvc.IMembershipManager teamManagerClient,
//        //                          ConfigurationSvc.ITimingManager timingClient,
//        //                          LoggerSvc.IStatusMessageLogger statusClient)
//        //{
//        //    //TODO: test if this services are available;
//        //    if (teamManagerClient == null) throw new ArgumentException("Team Manager Client Should not be null");
//        //    if (timingClient == null) throw new ArgumentException("Timing Client Should not be null");
//        //    if (statusClient == null) throw new ArgumentException("Status Client Should not be null");
//        //    this.teamManagerClient = teamManagerClient;
//        //    this.timingClient = timingClient;
//        //    this.statusClient = statusClient;
//        //    State = GameState.Ended;
//        //}

//        //private IEnumerable<PlayerSupervisor> supervisors;

//        //public void PerformGameProcess()
//        //{
//        //    var timings = timingClient.GetGameTimings();

//        //    StartGame();
//        //    StartTime(0);

//        //    for (int i = 0; i < timings.timeCount - 1; i++)
//        //    {
//        //        EndTime(i);
//        //        TimeOut();
//        //        StartTime(i + 1);
//        //    }
//        //    EndTime(0);
//        //    EndGame();
//        //}

//        //public void StartGame()
//        //{
//        //    statusClient.ShowStatusMessage("The game has started initialization...");

//        //    var dateofstart = timingClient.GetGameTimings().GameStartDate;
//        //    double millisecondsToWait = (dateofstart - DateTime.Now).TotalMilliseconds;
//        //    if (millisecondsToWait < 0) throw new NotImplementedException("here should be called mvc client with message that the time has run out");

//        //    statusClient.ShowStatusMessage("The game has been started");

//        //    ActivateSupervisors();

//        //    statusClient.ShowStatusMessage("SubArbiters has been activated");

//        //    State = GameState.Started;

//        //    statusClient.ShowStatusMessage("Game State is: "+State);
//        //}



//        //public void EndGame()
//        //{
//        //    statusClient.ShowStatusMessage("Ending of the game");
//        //    DisactivatePlayers();
//        //    DisactivateSupervisors();
//        //    statusClient.ShowStatusMessage("The game has been ended");
//        //}

//        //public void StartTime(int number)
//        //{
//        //    statusClient.ShowStatusMessage("Time " + number + " is starting");
//        //    var gameTime = timingClient.GetGameTimings().TimeLength;
//        //    Thread.Sleep(gameTime);
//        //    ActivatePlayers();
//        //    statusClient.ShowStatusMessage("Players are activated");
//        //}

//        //public void EndTime(int number)
//        //{
//        //    statusClient.ShowStatusMessage("Time " + number + "ended");
//        //    DisactivatePlayers();
//        //    statusClient.ShowStatusMessage("Players are disactivated");
//        //}

//        //public void TimeOut()
//        //{
//        //    statusClient.ShowStatusMessage("Time out started");
//        //    var pause = timingClient.GetGameTimings().TimeOutLength;
//        //    Thread.Sleep(pause);
//        //    statusClient.ShowStatusMessage("Time out ended");
//        //}

//        //public void ActivatePlayers()
//        //{
//        //    //Вот эти штуки надо имплементить через CommunicationService!
//        //    //    Это будет такой сервис, который умеет посылать сообщения роботам и хранит список готовых сообщений
//        //    throw new NotImplementedException();
//        //}

//        //public void DisactivatePlayers()
//        //{
//        //}

//        //public void ActivateSupervisors()
//        //{
//        //    var mem = teamManagerClient.GetMembership();
//        //    supervisors = SupervisorFactory(mem);
//        //    var threads = SupervisorThreadFactory(supervisors);
//        //    foreach (var t in threads)
//        //    {
//        //        t.Start();
//        //    }
//        //}

//        //public IEnumerable<PlayerSupervisor> SupervisorFactory(Arbiter.ConfigurationSvc.GameMembership mem)
//        //{
//        //    if (mem == null) throw new NullReferenceException("Team manager client returned null. But should return data for the team!");
//        //    var sv = mem.Teams.SelectMany(team => team.Players)
//        //                           .Select(player => new PlayerSupervisor(player));
//        //    return sv;
//        //}


//        //public IEnumerable<Thread> SupervisorThreadFactory(IEnumerable<PlayerSupervisor> supervisors)
//        //{
//        //    var threads = supervisors.Select(supervisor => new Thread(supervisor.CheckRules));
//        //    return threads;
//        //}

//        //public void DisactivateSupervisors()
//        //{
//        //    if (supervisors == null)
//        //    {
//        //        statusClient.ShowStatusMessage("Disactivating of supervisors: nothing to disactivate. Supervisors are null");
//        //        return;
//        //    }
//        //    foreach (var s in supervisors)
//        //    {
//        //        s.RequestStop();
//        //        //LoggerSvc.addLog
//        //    }
//        //}


//        public GameStatus PrepareGame(GameProperties gameProperties)
//        {
//            throw new NotImplementedException();
//        }

//        public GameStatus EndGame(GameProperties gameProperties)
//        {
//            throw new NotImplementedException();
//        }

//        public GameStatus TimeOut(GameProperties gameProperties)
//        {
//            throw new NotImplementedException();
//        }

//        public GameStatus SuspendGame(GameProperties gameProperties)
//        {
//            throw new NotImplementedException();
//        }

//        public GameStatus ResumeGame(GameProperties gameProperties)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
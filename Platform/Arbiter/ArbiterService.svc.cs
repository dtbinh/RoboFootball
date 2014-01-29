using System;
using System.ServiceModel;
using Arbiter.ConfigurationSvc;
using Arbiter.LoggerSvc;
using Arbiter.ServiceContracts;
using Arbiter.DataContracts;
using Arbiter.States;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : IGameProcessManager//ConfigurationSvc.INotificationManagerCallback
    {
        private GameContext gameContext;
        private TimeContext timeContext;
        private GameProperties gameProperties;
        public ArbiterService()
        {
            gameProperties = new GameProperties(new MembershipManagerClient(), 
                                                new TimingManagerClient(),
                                                new NotificationManagerClient( new InstanceContext(this)), 
                                                new LogManagerClient());
            timeContext = new TimeContext(gameProperties.Timing.GetGameTimings().TimeCount);
            gameContext = new GameContext(timeContext);
        }

        #region Implementation of IGameProcessManager

        public GameStatus ActivateGame()
        {
            gameContext.GoNext();
            var currentGameState = gameContext.CurrentGameState;
            return new GameStatus {Message = currentGameState.Description, State = currentGameState};
        }

        public GameStatus KillGame()
        {
            throw new NotImplementedException();
        }

        public GameStatus SuspendGame()
        {
            throw new NotImplementedException();
        }

        public GameStatus ResumeGame()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

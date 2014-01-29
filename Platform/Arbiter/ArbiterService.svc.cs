using System;
using System.ServiceModel;
using Arbiter.ServiceContracts;
using Arbiter.DataContracts;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : IGameProcessManager//ConfigurationSvc.INotificationManagerCallback
    {
        #region Implementation of IGameProcessManager

        public GameStatus ActivateGame()
        {
            throw new NotImplementedException();
        }

        public GameStatus StartGame()
        {
            throw new NotImplementedException();
        }

        public GameStatus StopGame()
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

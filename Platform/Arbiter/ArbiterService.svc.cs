using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Linq;
using Arbiter.ServiceContracts;
using Arbiter.DataContracts;

namespace Arbiter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService : IGameProcessManager//ConfigurationSvc.INotificationManagerCallback
    {
        GameProvider gpm;
        private LoggerSvc.StatusMessageLoggerClient statusClient;
        private ConfigurationSvc.TimingManagerClient timingClient;
        private ConfigurationSvc.MembershipManagerClient teamManagerClient;

        public ArbiterService()
        {

        }

        public DataContracts.GameStatus StartGame()
        {
            if (gpm.State != GameState.Ended)
                return new DataContracts.GameStatus
                {
                    GameState = gpm.State,
                    Message = "Could not start the game"
                };
 
            gpm.StartGame();

            if (gpm.State == GameState.Started)
                return new DataContracts.GameStatus
                {
                    GameState = gpm.State,
                    Message = String.Format{"The game has been started at {0}", DateTime.Now}
                };

            return new DataContracts.GameStatus
                {
                    GameState = gpm.State,
                    Message = "Could not start the game"
                };
        }

        public DataContracts.GameStatus StopGame()
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameStatus InteruptGame()
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameStatus ContinueGame()
        {
            throw new NotImplementedException();
        }



        //public ArbiterService()
        //{
        //    //statusClient= new LoggerSvc.StatusMessageLoggerClient();
        //    //timingClient = new ConfigurationSvc.TimingManagerClient();
        //    //teamManagerClient = new ConfigurationSvc.MembershipManagerClient();
        //    //gpm= new IGameProcessManager(teamManagerClient,timingClient,statusClient);
        //}

        //public void OnConfigurationIsReady()
        //{
        //    gpm.PerformGameProcess();
        //    statusClient.Close();
        //    timingClient.Close();
        //    teamManagerClient.Close();
        //}

       
    }
}

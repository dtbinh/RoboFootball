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
        IGameProvider gpm;
        GameProperties gp;
        private LoggerSvc.StatusMessageLoggerClient statusClient;
        private ConfigurationSvc.TimingManagerClient timingClient;
        private ConfigurationSvc.MembershipManagerClient teamManagerClient;

        public ArbiterService()
        {
            //gp.Logger = new Arbiter.LoggerSvc.StatusMessageLoggerClient();
            gp.Timing = new ConfigurationSvc.TimingManagerClient();
            gp.Membership = new ConfigurationSvc.MembershipManagerClient();
        }

        public DataContracts.GameStatus StartGame()
        {
            // check if game is could be started!
            // checks status of gpm!
            return gpm.StartGame(gp);


            //if (gpm.State != GameState.Ended)
            //    return new DataContracts.GameStatus
            //    {
            //        GameState = gpm.State,
            //        Message = "Could not start the game"
            //    };
 
            //gpm.StartGame();

            //if (gpm.State == GameState.Started)
            //    return new DataContracts.GameStatus
            //    {
            //        GameState = gpm.State,
            //        Message = String.Format{"The game has been started at {0}", DateTime.Now}
            //    };

            //return new DataContracts.GameStatus
            //    {
            //        GameState = gpm.State,
            //        Message = "Could not start the game"
            //    };
        }

        public DataContracts.GameStatus StopGame()
        {
            // check if game is could be ended!
            // checks status of gpm!
            return gpm.EndGame(gp);
        }

        public DataContracts.GameStatus SuspendGame()
        {
            // check if game is could be started!
            // checks status of gpm!
            return gpm.SuspendGame(gp);
        }

        public DataContracts.GameStatus ResumeGame()
        {
            return gpm.ResumeGame(gp);
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

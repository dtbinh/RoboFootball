using Configuration.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Configuration
{
    //TODO:Separate this service for 3 service: geometry tinimg and membership!
    public class ConfigurationService : INotificationManager, IGeometryManager, ITimingManager, IMembershipManager, IMembershipSetup, IRuleManager
    {
        public void SetGameGeometry(DataContracts.GameGeometry geometry)
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameGeometry GetGameGeometry()
        {
            throw new NotImplementedException();
        }

        public void SetGameTimings(DataContracts.GameTimings timings)
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameTimings GetGameTimings()
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameMembership GetMembership()
        {
            throw new NotImplementedException();
        }

        public DataContracts.TeamMembership GetTeam(byte TeamId)
        {
            throw new NotImplementedException();
        }

        public DataContracts.PlayerData GetPalyer(byte PlayerId, byte TeamId)
        {
            throw new NotImplementedException();
        }

        public DataContracts.TeamMembership RegisterTeam(byte TeamId)
        {
            throw new NotImplementedException();
        }

        public DataContracts.PlayerData RegisterRobot(byte PlayerId, byte TeamId)
        {
            throw new NotImplementedException();
        }

        public void UnRegisterRobot(byte PlayerId, byte TeamId)
        {
            throw new NotImplementedException();
        }

        public void SetGameRules(DataContracts.GameRules rules)
        {
            throw new NotImplementedException();
        }

        public DataContracts.GameRules GetGameRules()
        {
            throw new NotImplementedException();
        }

        public void ConfirmTeam(byte TeamId)
        {
            throw new NotImplementedException();
        }

        public void ConfigurationIsReady()
        {
            var Callback = OperationContext.Current.GetCallbackChannel<INotificationCallBack>();

            Callback.OnConfigurationIsReady();
        }
    }
}

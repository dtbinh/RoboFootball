using Deploy.MessageContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Deploy.ServiceContracts
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public interface IPlayerDeploy
    {
        // client module calls deploy and create request to it
        //one file-one robot- one session
        // During player deploy this service calls configuration service
        // it register robot in configuration and uploads robot program to robot directly with 
        //help of lejos scripts
  
        [OperationContract]
        void DeployPlayer(PlayerDeployInfo request);

        [OperationContract]
        void CancelDeploy(CancelDeployRequest request);

        [OperationContract]
        void UnDeploy(CancelDeployRequest request);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public interface ITeamUndeploy
    {
        [OperationContract]
        void UndeployTeam(UnDeployTeamRequest request);
    }
}
using Deploy.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Deploy.ServiceContracts
{
    public interface IDeployManager
    {
        // client module calls deploy and create request to it
        //one file-one robot- one session
        // During player deploy this service calls configuration service
        // it register robot in configuration and uploads robot program to robot directly with 
        //help of lejos scripts
  
        [OperationContract]
        void DeployPlayer(DeployInfo request);

        [OperationContract]
        void CancelDeploy(CancelDeployRequest request);

        [OperationContract]
        void UnDeploy(CancelDeployRequest request);
    }

    public interface ITeamUndeploy
    {
        [OperationContract]
        void UndeployTeam(TeamUnDeployRequest request);
    }
}
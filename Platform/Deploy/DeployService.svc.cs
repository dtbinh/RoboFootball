using Deploy.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Deploy
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]    
    public class DeployService : IDeployManager, ITeamUndeploy
    {
        public void DeployPlayer(DataContracts.DeployInfo request)
        {
            throw new NotImplementedException();
        }

        public void CancelDeploy(DataContracts.CancelDeployRequest request)
        {
            throw new NotImplementedException();
        }

        public void UnDeploy(DataContracts.CancelDeployRequest request)
        {
            throw new NotImplementedException();
        }

        public void UndeployTeam(DataContracts.TeamUnDeployRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

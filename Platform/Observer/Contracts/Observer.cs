using Observer.ConfigurationSvc;
using Observer.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Observer.ServiceContracts
{
    [ServiceContract]
    public interface IObserver
    {
        [OperationContract]
        PhysicInfo GetPlayerPhysicInfo(PlayerData playerData);

        [OperationContract]
        PhysicInfo GetAllRobotsPhysicInfo();
        
        [OperationContract]
        PhysicInfo GetBallPhysicInfo();
    }
}
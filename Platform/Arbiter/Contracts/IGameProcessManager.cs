using Arbiter.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Arbiter.ServiceContracts
{
    [ServiceContract]
    interface IGameProcessManager
    {
        [OperationContract]
        GameStatus ActivateGame();
        [OperationContract]
        GameStatus KillGame();
        [OperationContract]
        GameStatus SuspendGame();
        [OperationContract]
        GameStatus ResumeGame();
    }
}

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
        GameStatus StartGame();
        [OperationContract]
        GameStatus StopGame();
        [OperationContract]
        GameStatus SuspendGame();
        [OperationContract]
        GameStatus ResumeGame();
    }
}

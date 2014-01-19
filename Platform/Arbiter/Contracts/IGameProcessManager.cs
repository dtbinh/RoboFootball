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
        public GameStatus StartGame();
        [OperationContract]
        public GameStatus StopGame();
        [OperationContract]
        public GameStatus InteruptGame();
        [OperationContract]
        public GameStatus ContinueGame();
    }
}

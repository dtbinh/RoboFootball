using System;
using System.ServiceModel;

namespace Arbiter.ServiceContracts
{
    [ServiceContract]
    public interface IGameManager
    {
        [OperationContract]
        void TeamReady(int TemaId);
    }
}
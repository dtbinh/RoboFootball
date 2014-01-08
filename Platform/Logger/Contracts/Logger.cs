using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Logger.Contracts;

namespace Logger.ServiceContracts
{
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        void AddLog(GameLog log);
    }
}
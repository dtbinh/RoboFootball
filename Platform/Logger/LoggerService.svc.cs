using Logger.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Logger
{
    public class LoggerService : ILogger
    {
        public void AddLog(Contracts.GameLog log)
        {
            throw new NotImplementedException();
        }
    }
}

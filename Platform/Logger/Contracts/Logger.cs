using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Logger.DataContracts;

namespace Logger.ServiceContracts
{
    [ServiceContract]
    public interface ILogManager
    {
        [OperationContract]
        void AddLog(GameLog log);

    }

    [ServiceContract(CallbackContract = typeof(IStatusNotificationCallBack))]
    public interface IStatusMessageLogger
    {

        [OperationContract]
        void SubscribeForStatusMessages();

        // true when all teams are commited and time of testing ended
        [OperationContract]
        void ShowStatusMessage(string message);
    }

    public interface IStatusNotificationCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnShowStatusMessage(string message);
    }
}
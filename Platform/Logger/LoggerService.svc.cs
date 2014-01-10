using Logger.DataContracts;
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
    public class LoggerService : ILogManager, IStatusMessageLogger
    {
        public void AddLog(GameLog log)
        {
            throw new NotImplementedException();
        }

        ~LoggerService()
        {
            var subs = subscribers.Where(subscriber =>
                ((ICommunicationObject)subscriber).State == CommunicationState.Opened);
            foreach (var subscriber in subs)
            {
                ((ICommunicationObject)subscriber).Close();
                subscribers.Remove(subscriber);
            }
        }


        IList<IStatusNotificationCallBack> subscribers = new List<IStatusNotificationCallBack>();

        public void SubscribeForStatusMessages()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IStatusNotificationCallBack>();
            if (!subscribers.Contains(callback))
                subscribers.Add(callback);
        }

        public void ShowStatusMessage(string message)
        {

            //AddLog();

            foreach (var subscriber in subscribers)
            {
                if (((ICommunicationObject)subscriber).State == CommunicationState.Opened)
                {
                    subscriber.OnShowStatusMessage(message);
                }
            }
        }


    }
}

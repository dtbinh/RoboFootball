using System.ServiceModel;
using Communication.DataContracts;
using Communication.ServiceContracts;

namespace Communication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CommunicationService : ICommandManager
    {
        #region Implementation of ICommandManager

        public bool AddCommand(Command command)
        {
            if (command != null)
                return true;
            return false;
        }

        #endregion
    }
}

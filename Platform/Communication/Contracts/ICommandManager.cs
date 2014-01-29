using System.ServiceModel;
using Communication.DataContracts;

namespace Communication.ServiceContracts
{
    [ServiceContract]
    interface ICommandManager
    {
        [OperationContract]
        bool AddCommand(Command command);
    }
}

using Configuration.DataContracts;
using System.ServiceModel;

namespace Configuration.ServiceContracts
{
    [ServiceContract(CallbackContract = typeof(INotificationCallBack))]
    public interface INotificationManager
    {
        // true when all teams are commited and time of testing ended
        void ConfigurationIsReady();
    }

    public interface INotificationCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnConfigurationIsReady();
    }


    [ServiceContract]
    public interface IRuleManager
    {
        [OperationContract]
        void SetGameRules(GameRules rules);

        [OperationContract]
        GameRules GetGameRules();
    }


    [ServiceContract]
    public interface IGeometryManager
    {
        [OperationContract]
        void SetGameGeometry(GameGeometry geometry);

        [OperationContract]
        GameGeometry GetGameGeometry();
    }

    [ServiceContract]
    public interface ITimingManager
    {
        [OperationContract]
        void SetGameTimings(GameTimings timings);

        [OperationContract]
        GameTimings GetGameTimings();
    }
}
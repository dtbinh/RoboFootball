using Configuration.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Configuration.ServiceContracts
{
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
using Configuration.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Configuration.ServiceContracts
{

    [ServiceContract]
    public interface IGeometrySetup
    {
        [OperationContract]
        void SetGameGeometry(GameGeometry geometry);
    }

    [ServiceContract]
    public interface ITimingSetup
    {
        [OperationContract]
        void SetGameTimings(GameTimings timings);
    }
}